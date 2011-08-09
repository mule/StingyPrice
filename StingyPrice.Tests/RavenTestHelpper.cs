using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client.Embedded;
using StingyPrice.DAL.Models;

namespace StingyPrice.Tests
{
   public class RavenTestHelpper
   {
       private EmbeddableDocumentStore _documentStore;

       public EmbeddableDocumentStore DocumentStore { get { return _documentStore; } }

       public RavenTestHelpper()
       {
           _documentStore = new EmbeddableDocumentStore() {RunInMemory = true};
           _documentStore.Initialize();
       }


         public  void AddTestData()
      {

          var fakeStore = new Store() { Id = "Verkkokauppa", MainPageUrl = "http://www.verkkokauppa.com", Name = "Verkkokauppa" };

          var fakeStore2 = new Store() { Id = "Gigantti", MainPageUrl = "http://www.gigantti.fi", Name = "Gigantti" };


          var fakeProd1 = new Product()
          {
              Id = "Vekkokauppa20110801/Tietokoneet/Kannettavat/1",
              Name = "Acer Aspire 8920 ",
              Store = fakeStore,
              Price = 400,
              Created = DateTime.Now

          };


          var fakeProd2 = new Product()
          {
              Id = "Vekkokauppa20110801/Tietokoneet/Kannettavat/2",
              Name = "Acer ICONIA",
              Store = fakeStore,
              Price = 600,
              Created = DateTime.Now
          };
          var fakeProd3 = new Product()
          {
              Id = "Vekkokauppa20110801/Kannettavat/3",
              Name = "HP Compaq 620",
              Store = fakeStore,
              Price = 200,
              Created = DateTime.Now
          };

          var fakeProd4 = new Product()
          {
              Id = "Gigantti20110801/Tietokoneet/Kannettavat/2",
              Name = "Acer ICONIA",
              Store = fakeStore2,
              Price = 800,
              Created = DateTime.Now
          };

          using (var session = _documentStore.OpenSession())
          {
              session.Store(fakeProd1);
              session.Store(fakeProd2);
              session.Store(fakeProd3);
              session.Store(fakeProd4);

              session.SaveChanges();


          }

          

      }

   }
}
