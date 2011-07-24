using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using StingyPrice.DataAcquisition.Parsers;

namespace StingyPrice.DataAcquisition
{
   public class StoreBrowser
   {

       private HtmlWeb _client;
       private Parser _parser;
     

       public StoreBrowser()
       {
          
            _client = new HtmlWeb();
       }


       public void BrowseStore(Parser parser, string url)
       {
           _parser = parser;
           _parser.FoundCategory +=new EventHandler<ParserEventArgs>(parser_FoundCategory);

           var mainpageTask = new Task<HtmlDocument>(() => _client.Load(url));
          
           mainpageTask.Start();
          

           mainpageTask.ContinueWith((t) => _parser.ParseMainpage(t.Result));






       }

       private void parser_FoundCategory(object sender, ParserEventArgs e)
       {
           Trace.WriteLine(String.Format("Category found: {0} {1}",e.CategoryName,e.CategoryName));
           var categoryTask = new Task<HtmlDocument>(() => _client.Load(e.CategoryLink));
           categoryTask.Start();
           categoryTask.ContinueWith((t) => _parser.ParseCategoryPage(t.Result));

       }
   }
}
