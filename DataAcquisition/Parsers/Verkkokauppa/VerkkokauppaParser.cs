using System;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using HtmlAgilityPack;
using StingyPrice.DAL.Models;
using StingyPrice.DataAcquisition.Parsers;
using StingyPriceDAL.Models;

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

                        
                            OnFoundCategory( new ParserEventArgs() { CategoryLink = href, CategoryName = name, ParentCategoryId = "root"});
                    }
                }

            }
        }

        public override void ParseCategoryPage(HtmlDocument result,string parentCategoryId) {
          base.ParseCategoryPage(result,parentCategoryId);

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
                OnFoundCategory( new ParserEventArgs(){CategoryLink = href, CategoryName = name, ParentCategoryId = parentCategoryId});

              }
            }
          }
          else
          {
              //No category list found, lets check for product list then

              var prodNodes = result.DocumentNode.SelectNodes(@"//div[@class='productList']//a[@class='productInfo']");

              if (prodNodes != null)
              {
                  foreach (HtmlNode prodNode in prodNodes)
                  {
                      if (prodNode != null)
                      {
                          string href = prodNode.Attributes["href"].Value;

                          Trace.WriteLine(String.Format("Thread {0}: Found product page link {1}",
                                                        Thread.CurrentThread.ManagedThreadId, href));

                          OnFoundProductLink(new ParserEventArgs(){CategoryName = parentCategoryId, ProductLink = href});
                      }
                  }


              }
              else
              {
                  Trace.WriteLine("No product links found");
              }
          }



        }

        public override void ParseProductPage(HtmlDocument document, string parentCategoryId)
        {

          var prod = new Product();
            Trace.WriteLine(String.Format("Thread {0}: Parsing productpage", Thread.CurrentThread.ManagedThreadId));

            if(document==null)
                throw  new ArgumentNullException("Parser was given an empty product page");

          var nameNode = document.DocumentNode.SelectSingleNode(@"//h1[@id='productName']");

          if (nameNode != null)
            prod.Name = nameNode.InnerText;
          else
          {
              //TODO: add irregular product link handling here 
          }


          var priceNode = document.DocumentNode.SelectSingleNode(@"//span[@class='hintabig']");

          if (priceNode != null)
          {
            var priceStr = priceNode.InnerText;

            var match = Regex.Match(priceStr, @"\d+[,.]\d+");


            if (match.Success)
            {
              priceStr = match.Value;
              double price;

              if (!Double.TryParse(priceStr, NumberStyles.Currency, CultureInfo.CurrentCulture, out price))
                if (!Double.TryParse(priceStr, NumberStyles.Any, CultureInfo.InvariantCulture, out price))
                  price = Double.NaN;


              prod.Price = price;

            }
            else
            {
              prod.Price = double.NaN;

            }
          }
          else
          {
            prod.Price = double.NaN;
          }


          OnProductParsed(new ParserEventArgs(){ParentCategoryId = parentCategoryId, Product = prod});
          
          


        }
        protected override void OnFoundCategory(ParserEventArgs args)
        {
            base.OnFoundCategory(args);



        }

        protected override void OnFoundProductLink(ParserEventArgs args)
        {
            base.OnFoundProductLink(args);
        }


        


      
    }
}
