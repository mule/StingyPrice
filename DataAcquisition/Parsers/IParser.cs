using HtmlAgilityPack;

namespace DataAcquisition.Parsers
{
   public interface IParser
   {

       
       void ParseMainpage(HtmlDocument document);

   }
}
