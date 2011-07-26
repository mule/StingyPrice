using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Schedulers;
using HtmlAgilityPack;
using StingyPrice.DataAcquisition.Parsers;
using StingyPriceDAL.Models;

namespace StingyPrice.DataAcquisition {
  public class StoreBrowser {

    private HtmlWeb _client;
    private Parser _parser;
    //private List<Task> _tasks;
    private BlockingCollection<Task> _tasks;
    TaskFactory _factory;

    public StoreSearch SearchResult { get; set; }




    public StoreBrowser() {

      _client = new HtmlWeb();

      _factory = new TaskFactory(new LimitedConcurrencyLevelTaskScheduler(15));
      _tasks = new BlockingCollection<Task>();




    }




    public void BrowseStore(Parser parser, Store store) {
      _parser = parser;
      _parser.FoundCategory += new EventHandler<ParserEventArgs>(parser_FoundCategory);
      _parser.FounndProduct += new EventHandler<ParserEventArgs>(_parser_FounndProduct);


      SearchResult = new StoreSearch() {
        Categories =
            new CategoryTree() { Root = new Category() { Name = "root", SubCategories = new List<Category>() } }

      };



      var document = _client.Load(store.MainPageUrl);

      if (document != null)
        parser.ParseMainpage(document);
      else {
        throw new InvalidOperationException(String.Format(@"Could not load main page from {0}", store.MainPageUrl));
      }



        while (_tasks.Where(t => t.IsCompleted == false).Count() > 0) {
          Thread.Sleep(5000);
          
        }
      }



    

    void _parser_FounndProduct(object sender, ParserEventArgs e) {
      Trace.WriteLine(String.Format("Thread {0} Product found: {1} {2}", Thread.CurrentThread.ManagedThreadId, e.ParentCategoryName, e.ProductLink));

    }

    private void parser_FoundCategory(object sender, ParserEventArgs e) {
      Trace.WriteLine(String.Format("Thread {0} Category found: {1} {2}", Thread.CurrentThread.ManagedThreadId, e.CategoryName, e.CategoryLink));

      var parent = SearchResult.Categories.FindCategory(e.ParentCategoryName);

      if (parent == null)
        throw new InvalidOperationException("Parent category not found");
      else {
        parent.AddSubCategory(new Category() { Name = e.CategoryName });
      }


      var categoryTask = new Task<HtmlDocument>(() => _client.Load(e.CategoryLink));

      var task = _factory.StartNew<HtmlDocument>(() => { return _client.Load(e.CategoryLink); }).ContinueWith(
          (t) => _parser.ParseCategoryPage(t.Result, e.ParentCategoryName));

   
        _tasks.Add(task);

      





    }
  }
}
