using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using StingyPrice.DataAcquisition.Parsers;
using StingyPriceDAL.Models;

namespace StingyPrice.DataAcquisition {
  public class StoreBrowser {

    private HtmlWeb _client;
    private Parser _parser;
    private List<Task> _tasks;

    public StoreSearch SearchResult { get; set; }

   


    public StoreBrowser() {

      _client = new HtmlWeb();
      _tasks = new List<Task>();
    
    }


    public void BrowseStore(Parser parser, Store store) {
      _parser = parser;
      _parser.FoundCategory += new EventHandler<ParserEventArgs>(parser_FoundCategory);

      var document = _client.Load(store.MainPageUrl);

      if (document != null)
        parser.ParseMainpage(document);
      else
      {
        throw new InvalidOperationException(String.Format(@"Could not load main page from {0}", store.MainPageUrl));
      }

      Task.WaitAll(_tasks.ToArray());



    }

    private void parser_FoundCategory(object sender, ParserEventArgs e) {
      Trace.WriteLine(String.Format("Thread {0} Category found: {1} {2}",Thread.CurrentThread.ManagedThreadId,  e.CategoryName, e.CategoryLink));

      lock (_tasks) {
      while (_tasks.Where(tk => tk.IsCompleted != true).Count() > 10) {
        Task.WaitAny(_tasks.ToArray(), new TimeSpan(0, 0, 0, 20));

      }

      var categoryTask = new Task<HtmlDocument>(() => _client.Load(e.CategoryLink));
      if(_tasks==null)
        _tasks = new List<Task>();

        _tasks.Add(categoryTask);
        categoryTask.Start();
        categoryTask.ContinueWith((t) => _parser.ParseCategoryPage(t.Result, e.ParentCategoryName));
      }




    }
  }
}
