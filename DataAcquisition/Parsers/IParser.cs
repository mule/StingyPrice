using HtmlAgilityPack;
using StingyPriceDAL.Models;

namespace StingyPrice.DataAcquisition.Parsers
{
   public interface IParser
   {

       
       void ParseMainpage(HtmlDocument document);
     void ParseCategoryPage(HtmlDocument document, string parentCategoryId);
       Product ParseProductPage(HtmlDocument document, string parentCategoryId);



   }
}
