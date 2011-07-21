using System.Collections.Generic;
using System.Linq;
using StingyPrice.DAL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using StingyPrice.DAL.Models;
using Raven.Client.Document;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using StingyPrice.Models;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StingyPrice.Tests {


  /// <summary>
  ///This is a test class for RavenRepositoryTest and is intended
  ///to contain all RavenRepositoryTest Unit Tests
  ///</summary>
  [TestClass()]
  public class RavenRepositoryTest {


    private TestContext testContextInstance;
    private static CategoryTree _testData;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext {
      get {
        return testContextInstance;
      }
      set {
        testContextInstance = value;
      }
    }

    #region Additional test attributes
    // 
    //You can use the following additional attributes as you write your tests:
    //
    //Use ClassInitialize to run code before running the first test in the class
    //[ClassInitialize()]
    //public static void MyClassInitialize(TestContext testContext)
    //{
    //}
    ////
    //Use ClassCleanup to run code after all tests in a class have run
    [ClassCleanup()]
    public static void MyClassCleanup()
    {
      deleteTestData();
    }
    //
    //Use TestInitialize to run code before running each test
    //[TestInitialize()]
    //public void MyTestInitialize()
    //{
    //}
    //
    //Use TestCleanup to run code after each test has run
    //[TestCleanup()]
    //public void MyTestCleanup()
    //{
    //}
    //
    #endregion





    [TestMethod()]
    public void AddTest() {

      var docStore = new Raven.Client.Document.DocumentStore { Url = "http://localhost:8080", DefaultDatabase =  "UnitTestDB"};
      docStore.Initialize();
      var rep = new RavenRepository(docStore);
      createTestData();
      rep.Add<CategoryTree>(_testData);
      rep.Save();

     var result = rep.All<CategoryTree>().FirstOrDefault();

      Assert.IsNotNull(result);
      Assert.IsInstanceOfType(result,typeof(CategoryTree));
      Assert.IsTrue(result.Root.SubCategories.Count()==2 );



    }


    private static void createTestData() {

     

      //var prod = new Product() { Name = "TestProduct", Price = 10.0, Store = new Store() { Name = "TestStore" } };
      //var prodGroup = new ProductGroup() { Name = "TestGroup", Products = new List<Product>() { prod } };


      var subCategory1 = new Category() { Name = "SubCategory1" };
      var subCategory2 = new Category() { Name = "SubCategory2" };
      var root = new Category() { Name = "Root", SubCategories = new List<Category>() { subCategory1,subCategory2 } };

      _testData = new CategoryTree() {Root = root};


    }

    private static void deleteTestData()
    {
      var docStore = new Raven.Client.Document.DocumentStore { Url = "http://localhost:8080" };
      docStore.Initialize();

      var session = docStore.OpenSession();
      var categorytrees = session.Query<CategoryTree>();

      foreach (var categoryTree in categorytrees)
      {
        session.Delete(categoryTree);
      }

      session.SaveChanges();
   

      
    }
  }
}
