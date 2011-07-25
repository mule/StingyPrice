using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using HtmlAgilityPack;
using StingyPriceDAL.Models;


namespace StingyPrice.DataAcquisition.Parsers
{
   public abstract class Parser : IParser
    {
        


        public event EventHandler<ParserEventArgs> FoundCategory;
       public event EventHandler<ParserEventArgs> FounndProduct;


       public virtual void ParseMainpage(HtmlAgilityPack.HtmlDocument document)
       {
           
       }

       protected virtual void OnFoundCategory(ParserEventArgs args)
       {
           if (FoundCategory != null)
               FoundCategory(this, args);
       


       }

       protected virtual  void OnFoundProduct(ParserEventArgs args)
       {
           if (FounndProduct != null)
               FounndProduct(this, args);

       }


       public virtual void ParseCategoryPage(HtmlDocument result, string parentCategory)
       {



         


       }


       public virtual Product ParseProductPage(HtmlDocument document, string parentCategory)
       {
           return new Product();
       }
    }


   public class ParserEventArgs : EventArgs
   {
     public string ParentCategoryName; 
       public string CategoryName;
       public string CategoryLink;
       public string ProductLink { get; set; }


       public ParserEventArgs()
       {


       }

   }
}
