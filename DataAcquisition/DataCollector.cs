using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StingyPrice.DataAcquisition.Parsers;
using StingyPrice.DataAcquisition.Parsers.Verkkokauppa;
using StingyPriceDAL.Models;
using StingyPriceDAL.Repositories;

namespace StingyPrice.DataAcquisition
{
   public  class DataCollector
   {
       private StoreSearch _currentSearch;
       private Parser _parser;
       private StoreBrowser _browser;
       private RavenRepository _repository;


       public void CollectStoreData(Store store)
       {
           _parser = new VerkkokauppaParser();

           _parser.FoundCategory += new EventHandler<ParserEventArgs>(_parser_FoundCategory);
           _parser.FounndProduct += new EventHandler<ParserEventArgs>(_parser_FounndProduct);

           _browser = new StoreBrowser();
          


       }

       void _parser_FounndProduct(object sender, ParserEventArgs e)
       {
           
       }

       void _parser_FoundCategory(object sender, ParserEventArgs e)
       {
           throw new NotImplementedException();
       }


   }
}
