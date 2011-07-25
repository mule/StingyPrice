using HtmlAgilityPack;

namespace StingyPrice.DataAcquisition.Parsers
{
   public interface IParser
   {

       
       void ParseMainpage(HtmlDocument document);
     void ParseCategoryPage(HtmlDocument document, string parentCategory);



   }
}
