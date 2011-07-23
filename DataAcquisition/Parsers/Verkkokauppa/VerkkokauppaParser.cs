using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DataAcquisition.Parsers;
using HtmlAgilityPack;

namespace StingyPrice.Parsers.Verkkokauppa
{
    public class VerkkokauppaParser : IParser
    {

        public delegate void ParserEventHandler(object sender, ParserEventArgs args);


        public event ParserEventHandler FoundCategory;



        public void ParseMainpage(HtmlDocument document)
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


                        FoundCategory(this, new ParserEventArgs() { CategoryLink = href, CategoryName = name });
                    }
                }

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
}
