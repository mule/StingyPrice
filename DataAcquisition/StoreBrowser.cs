using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Schedulers;
using HtmlAgilityPack;
using StingyPrice.DAL.Models;
using StingyPrice.DataAcquisition.Parsers;

namespace StingyPrice.DataAcquisition
{
    public class StoreBrowser
    {

        private HtmlWeb _client;
        private Parser _parser;
        private BlockingCollection<Task> _tasks;
        TaskFactory _factory;

     




        public StoreBrowser()
        {

            _client = new HtmlWeb();

            _factory = new TaskFactory(new LimitedConcurrencyLevelTaskScheduler(15));
            _tasks = new BlockingCollection<Task>();




        }




        public void BrowseStore(Parser parser, Store store)
        {
            _parser = parser;
            _parser.FoundCategory += new EventHandler<ParserEventArgs>(parser_FoundCategory);
            _parser.FoundProductLink += new EventHandler<ParserEventArgs>(_parser_FoundProduct);

            LimitedConcurrencyLevelTaskScheduler.UnobservedTaskException += new EventHandler<UnobservedTaskExceptionEventArgs>(LimitedConcurrencyLevelTaskScheduler_UnobservedTaskException);



            var document = _client.Load(store.MainPageUrl);

            if (document != null)
                parser.ParseMainpage(document);
            else
            {
                throw new InvalidOperationException(String.Format(@"Could not load main page from {0}", store.MainPageUrl));
            }

          var completedTasks = _tasks.Where(t => t.IsCompleted);

          foreach (Task completedTask in completedTasks)
          {
            completedTask.Dispose();
          }



            while (_tasks.Where(t => t.IsCompleted == false).Count() > 0)
            {
                try
                {
                    Task.WaitAll(_tasks.ToArray());
                    Thread.Sleep(5000);
                }
                catch (AggregateException ae)
                {

                    ae.Handle((x) =>
                                  {
                                      if (x is InvalidOperationException)
                                      {

                                          //TODO: add logging here
                                          Trace.WriteLine(x.Message);
                                          return true;
                                      }

                                      return false;
                                  });


                }

            }
        }

        void LimitedConcurrencyLevelTaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            e.Exception.Handle((x) =>
            {
                if (x is InvalidOperationException)
                {

                    //TODO: add logging here
                    Trace.WriteLine(x.Message);
                    return true;
                }
                return false;

            });



        }





        void _parser_FoundProduct(object sender, ParserEventArgs e)
        {
            Trace.WriteLine(String.Format("Thread {0} Product found: {1} {2}", Thread.CurrentThread.ManagedThreadId, e.ParentCategoryId, e.ProductLink));


          var task = _factory.StartNew<HtmlDocument>(() => { return _client.Load(e.ProductLink); }).ContinueWith(
            (t) => _parser.ParseProductPage(t.Result, e.CategoryName));




        }

        private void parser_FoundCategory(object sender, ParserEventArgs e)
        {
            Trace.WriteLine(String.Format("Thread {0} Category found: {1} {2}", Thread.CurrentThread.ManagedThreadId, e.CategoryName, e.CategoryLink));


            var task = _factory.StartNew<HtmlDocument>(() => { return _client.Load(e.CategoryLink); }).ContinueWith(
        (t) => _parser.ParseCategoryPage(t.Result, e.ParentCategoryId));


            _tasks.Add(task);



        }
    }
}
