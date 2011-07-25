using System;
using System.Diagnostics;
using System.Threading;
using HtmlAgilityPack;
using StingyPrice.DataAcquisition.Parsers;

namespace StingyPrice.DataAcquisition.Parsers.Verkkokauppa
{
    public class VerkkokauppaParser : Parser
    {

        public override void ParseMainpage(HtmlDocument document)
        {
            var navbarNodes =
                document.DocumentNode.SelectNodes(
                    @"//div[@id='mainNav']/ul[@class='navigation'][1]/li[contains(@class,'cat')]/a");
            if (navbarNodes != null)
            {
                foreach (var node in navbarNodes)
                {
                    if (node != null)
                    {
                        string href = node.Attributes["href"].Value;
                        string name = node.InnerText;

                        
                            OnFoundCategory( new ParserEventArgs() { CategoryLink = href, CategoryName = name, ParentCategoryName = "root"});
                    }
                }

            }
        }

        public override void ParseCategoryPage(HtmlDocument result,string parentCategory) {
          base.ParseCategoryPage(result,parentCategory);

          Trace.WriteLine(String.Format(@"Thread {0} Parsing category page:", Thread.CurrentThread.ManagedThreadId));

          if (result == null)
            throw new ArgumentNullException("Empty document passed to parser");

          var subCatNodes = result.DocumentNode.SelectNodes(@"//div[@class='tags subcategories']/ul/li/a");

          if (subCatNodes != null)
          {
            foreach (HtmlNode subCatNode in subCatNodes)
            {
              if (subCatNode != null)
              {

                string href = subCatNode.Attributes["href"].Value;
                string name = subCatNode.InnerText;

                Trace.WriteLine(String.Format("Thread {0}: Found subcategory {1} {2}",Thread.CurrentThread.ManagedThreadId, name,href));
                OnFoundCategory( new ParserEventArgs(){CategoryLink = href, CategoryName = name, ParentCategoryName = parentCategory});

              }
            }


          }



        }
        protected override void OnFoundCategory(ParserEventArgs args)
        {
            base.OnFoundCategory(args);



        }
        


      
    }
}
