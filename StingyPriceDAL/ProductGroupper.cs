using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using Raven.Abstractions.Data;
using Raven.Abstractions.Indexing;
using Raven.Client;
using Raven.Client.Document;

using StingyPriceDAL.Models;

namespace StingyPriceDAL
{
   public  class ProductGroupper
    {

        private DocumentStore _store;
        private IDocumentSession _session;

        public ProductGroupper(DocumentStore docStore)
        {
            Contract.Requires(docStore!=null);

            _store = docStore;
          
            _session = docStore.OpenSession();



          
           

        }


       /// <summary>
       /// Does a full text search from Raven.
       /// </summary>
       /// <param name="searchStr"></param>
       /// <returns> Collection of ProductGroups found by search</returns>
        public Dictionary<string,List<Product>> SearchStoreProductGroups(string searchStr)
       {
         var productGroups = new Dictionary<string, List<Product>>();
         var result =
           _session.Advanced.LuceneQuery<Product>("ProductsByName").WhereContains("Name", searchStr);

          if(result!=null)
            foreach (Product prod in result)
            {
              if(prod.Store!=null)
              {
                if (productGroups.ContainsKey(prod.Store.Name))
                  productGroups[prod.Store.Name].Add(prod);
                else
                {
                  productGroups.Add(prod.Store.Name,new List<Product>(){prod});

                }
              }


            }


         return productGroups;
       }
    }
}
