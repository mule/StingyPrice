﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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


       public virtual void ParseCategoryPage(HtmlDocument result, string parentCategory)
       {



         


       }
    }


   public class ParserEventArgs : EventArgs
   {
     public string ParentCategoryName; 
       public string CategoryName;
       public string CategoryLink;


       public ParserEventArgs()
       {


       }

   }
}