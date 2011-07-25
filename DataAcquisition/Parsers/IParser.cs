using HtmlAgilityPack;
using StingyPriceDAL.Models;

namespace StingyPrice.DataAcquisition.Parsers
{
   public interface IParser
   {

       
       void ParseMainpage(HtmlDocument document);
     void ParseCategoryPage(HtmlDocument document, string parentCategory);
       Product ParseProductPage(HtmlDocument document, string parentCategory);



   }
}
