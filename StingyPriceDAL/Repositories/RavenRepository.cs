using System;
using System.Collections.Generic;
using System.Linq;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;
using Raven.Client.Linq;
using StingyPrice.DAL.Models;
using StingyPriceDAL.Models;

namespace StingyPriceDAL.Repositories {
  public class RavenRepository : IRepository {
    private EmbeddableDocumentStore _store;
    private IDocumentSession _session;

    public RavenRepository(EmbeddableDocumentStore store) {
      _store = store;
      _session = _store.OpenSession();
        
    }

    public T SingleOrDefault<T>(Func<T, bool> predicate) where T : IModel {
      return _session.Query<T>().SingleOrDefault(predicate);
    }
     
    public IRavenQueryable<T> All<T>() where T : IModel {
      return _session.Query<T>();
      
        
    }

    public void Add<T>(T item) where T : IModel {
      _session.Store(item);
    }

    public void Delete<T>(T item) where T : IModel {
      _session.Delete(item);
    }

    

    public void Save() {
      _session.SaveChanges();
    }


    public Dictionary<string, List<Product>> SearchStoreProductGroups(string searchStr)
    {
        var productGroups = new Dictionary<string, List<Product>>();
        var result =
          _session.Advanced.LuceneQuery<Product>("ProductsByName").WhereContains("Name", searchStr);

        if (result != null)
            foreach (Product prod in result)
            {
                if (prod.Store != null)
                {
                    if (productGroups.ContainsKey(prod.Store.Name))
                        productGroups[prod.Store.Name].Add(prod);
                    else
                    {
                        productGroups.Add(prod.Store.Name, new List<Product>() { prod });

                    }
                }


            }


        return productGroups;
    }
  }
}