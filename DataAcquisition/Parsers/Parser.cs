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
       public event EventHandler<ParserEventArgs> FoundProductLink;
     public event EventHandler<ParserEventArgs> ProductParsed;


       public virtual void ParseMainpage(HtmlAgilityPack.HtmlDocument document)
       {
           
       }

       protected virtual void OnFoundCategory(ParserEventArgs args)
       {
           if (FoundCategory != null)
               FoundCategory(this, args);
       


       }

       protected virtual  void OnFoundProductLink(ParserEventArgs args)
       {
           if (FoundProductLink != null)
               FoundProductLink(this, args);

       }

     protected virtual void OnProductParsed(ParserEventArgs args)
     {

       if (ProductParsed != null)
         ProductParsed(this, args);

     }


       public virtual void ParseCategoryPage(HtmlDocument result, string parentCategoryId)
       {



         


       }


       public virtual void ParseProductPage(HtmlDocument document, string parentCategoryId)
       {
           
       }
    }


   public class ParserEventArgs : EventArgs
   {
     public string ParentCategoryId; 
       public string CategoryName;
       public string CategoryLink;
       public string ProductLink { get; set; }
     public Product Product { get; set; }


       public ParserEventArgs()
       {


       }

   }
}
