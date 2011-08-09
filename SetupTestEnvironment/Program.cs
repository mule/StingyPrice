using System;
using Raven.Client;
using StingyPrice.DAL.Models;


namespace SetupTestEnvironment
{
    class Program
    {
        static void Main(string[] args)
        {

            var documentStore = new Raven.Client.Document.DocumentStore { Url = "http://localhost:8080", DefaultDatabase = "TestDB" };
            documentStore.Initialize();
            var session = documentStore.OpenSession();


            //FetchTestStoreDataToDb(session);
            CreateTestStoreSearchesDataToDb(session);


        }



        //public static void FetchTestStoreDataToDb(IDocumentSession session)
        //{
        //    var browser = new StoreBrowser();

        //    browser.BrowseStore(new VerkkokauppaParser(), new Store() { MainPageUrl = @"http://www.verkkokauppa.com", Name = "Verkkokauppa" });

        //    //session.Store(browser.SearchResult);




        //}


        //public static void CreateTestStoreSearchesDataToDb(IDocumentSession session) {
        //  var fakeStore = new Store() { Id = "Verkkokauppa", MainPageUrl = "http://www.verkkokauppa.com", Name = "Verkkokauppa" };

        //  var fakeStore2 = new Store() { Id = "Gigantti", MainPageUrl = "http://www.gigantti.fi", Name = "Gigantti" };


        //  var fakeProd1 = new Product() {
        //    Id = "Vekkokauppa/Tietokoneet/Kannettavat/1",
        //    Name = "Acer Aspire 8920 ",
        //    Price = 400,
        //    Created = DateTime.Now

        //  };


        //  var fakeProd2 = new Product() {
        //    Id = "Vekkokauppa/Tietokoneet/Kannettavat/2",
        //    Name = "Acer ICONIA",           
        //    Price = 600,
        //    Created = DateTime.Now
        //  };
        //  var fakeProd3 = new Product() {
        //    Id = "Vekkokauppa/Kannettavat/3",
        //    Name = "HP Compaq 620",

        //    Price = 200,
        //    Created = DateTime.Now
        //  };

        //  var fakeProd4 = new Product() {
        //    Id = "Gigantti/Tietokoneet/Kannettavat/2",
        //    Name = "Acer ICONIA",
        //    Price = 800,
        //    Created = DateTime.Now
        //  };

        //  fakeStore.Products = new List<Product> {fakeProd1, fakeProd2, fakeProd3};
        //  fakeStore2.Products = new List<Product> {fakeProd4};


        //  session.Store(fakeStore);
        //  session.Store(fakeStore2);

        //  session.SaveChanges();



        //}


        public static void CreateTestStoreSearchesDataToDb(IDocumentSession session) {
          var fakeStore = new Store() { Id = "Verkkokauppa", MainPageUrl = "http://www.verkkokauppa.com", Name = "Verkkokauppa" };

          var fakeStore2 = new Store() { Id = "Gigantti", MainPageUrl = "http://www.gigantti.fi", Name = "Gigantti" };


          var fakeProd1 = new Product() {
            Id = "Vekkokauppa20110801/Tietokoneet/Kannettavat/1",
            Name = "Acer Aspire 8920 ",
            Store = fakeStore,
            Price = 400,
            Created = DateTime.Now

          };


          var fakeProd2 = new Product() {
            Id = "Vekkokauppa20110801/Tietokoneet/Kannettavat/2",
            Name = "Acer ICONIA",
            Store = fakeStore,
            Price = 600,
            Created = DateTime.Now
          };
          var fakeProd3 = new Product() {
            Id = "Vekkokauppa20110801/Kannettavat/3",
            Name = "HP Compaq 620",
            Store = fakeStore,
            Price = 200,
            Created = DateTime.Now
          };

          var fakeProd4 = new Product() {
            Id = "Gigantti20110801/Tietokoneet/Kannettavat/2",
            Name = "Acer ICONIA",
            Store = fakeStore2,
            Price = 800,
            Created = DateTime.Now
          };


          session.Store(fakeProd1);
          session.Store(fakeProd2);
          session.Store(fakeProd3);
          session.Store(fakeProd4);

          session.SaveChanges();



        }



        //public static void CreateTestStoreSearchesDataToDb(IDocumentSession session)
        //{
        //    var fakeStore = new Store() { Id = "Verkkokauppa", MainPageUrl = "http://www.verkkokauppa.com", Name = "Verkkokauppa" };

        //    var fakeStore2 = new Store() { Id = "Gigantti", MainPageUrl = "http://www.gigantti.fi", Name = "Gigantti" };

      //var fakeProd1 = new Product() {
      //  Id = "Vekkokauppa20110801/Tietokoneet/Kannettavat/1",
      //  Name = "Acer Aspire 8920 ",
      //  Store = fakeStore,
      //  Price = 400
      //};


      //var fakeProd2 = new Product() {
      //  Id = "Vekkokauppa20110801/Tietokoneet/Kannettavat/2",
      //  Name = "Acer ICONIA",
      //  Store = fakeStore,
      //  Price = 600
      //};
      //var fakeProd3 = new Product() {
      //  Id = "Vekkokauppa20110801/Kannettavat/3",
      //  Name = "HP Compaq 620",
      //  Store = fakeStore,
      //  Price = 200
      //};


        //    var testCat1 = new Category() { Id = "Vekkokauppa20110801/Tietokoneet/Kannettavat", Name = "Kannettavat", Products = new List<Product>(){fakeProd1,fakeProd2}};
        //    var testCat2 = new Category()
        //                       {
        //                           Id = "Gigantti31072011/Tietokoneet/Kannettavat",
        //                           Name = "Kannettavat",
        //                           Products = new List<Product> {fakeProd3}
        //                       };


        //   session.Store(testCat1);
        //   session.Store(testCat2);
        //    session.SaveChanges();


        //}


        //public static void StoreCategoryDataToDb(IDocumentSession session)
        //{
        //    var doc = new XmlDocument();
        //    var categoryNameList = new List<string>();
        //    var catTree = new CategoryTree() { Root = new Category() { Name = "Root", SubCategories = new List<Category>() } };




        //    doc.Load(@"kategoriat.xml");

        //    var nodes = doc.SelectNodes(@"//dbo.Tuote[SisaltaaKategorioita='1' ]");

        //    foreach (XmlNode node in nodes)
        //    {

        //        if (node.InnerText.Split(' ')[0].EndsWith("1"))
        //            categoryNameList.Add(node.InnerText.TrimEnd('1'));
        //    }


        //    foreach (string catName in categoryNameList)
        //    {
        //        Trace.WriteLine(catName);
        //        catTree.Root.SubCategories.Add(new Category() { Name = catName });

        //    }

        //    session.Store(catTree);
        //    session.SaveChanges();
        //}

    }

}
