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

                        
                            OnFoundCategory( new ParserEventArgs() { CategoryLink = href, CategoryName = name });
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
