using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using Raven.Abstractions.Indexing;
using Raven.Client;
using Raven.Client.Document;

using StingyPriceDAL.Models;

namespace StingyPriceDAL
{
   public  class TextSearchGroupper
    {

        private DocumentStore _store;
        private IDocumentSession _session;

        public TextSearchGroupper(DocumentStore docStore)
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
       public ICollection<Product> SearchGroups(string searchStr)
       {
       //    var result = _session.Advanced.LuceneQuery<Product>().Where(p => p.Name.Contains(searchStr));
         var query =
           _session.Advanced.LuceneQuery<Product>().WhereContains("Name", searchStr);

      
        
           return query.ToList();
       }
    }
}
