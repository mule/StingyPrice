using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;


namespace StingyPrice.DataAcquisition.Parsers
{
   public abstract class Parser : IParser
    {
        


        public event EventHandler<ParserEventArgs> FoundCategory;


       public virtual void ParseMainpage(HtmlAgilityPack.HtmlDocument document)
       {
           
       }

       protected virtual void OnFoundCategory(ParserEventArgs args)
       {
           if (FoundCategory != null)
               FoundCategory(this, args);
       


       }


       public void ParseCategoryPage(HtmlDocument result)
       {
           throw new NotImplementedException();
       }
    }


   public class ParserEventArgs : EventArgs
   {
       public string CategoryName;
       public string CategoryLink;


       public ParserEventArgs()
       {


       }

   }
}
