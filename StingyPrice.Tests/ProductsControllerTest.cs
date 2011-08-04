using StingyPrice.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using StingyPriceDAL.Repositories;

namespace StingyPrice.Tests
{
    
    
    /// <summary>
    ///This is a test class for CategoriesControllerTest and is intended
    ///to contain all CategoriesControllerTest Unit Tests
    ///</summary>
  [TestClass()]
  public class ProductsControllerTest {


    private TestContext testContextInstance;

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
    //
    //Use ClassCleanup to run code after all tests in a class have run
    //[ClassCleanup()]
    //public static void MyClassCleanup()
    //{
    //}
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


    /// <summary>
    ///A test for Search
    ///</summary>
    // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    // whether you are testing a page, web service, or a WCF service.
    [TestMethod()]
    //[HostType("ASP.NET")]
    //[AspNetDevelopmentServerHost("C:\\gitRepositories\\StingyPrice\\StingyPrice", "/")]
    //[UrlToTest("http://localhost:57460/")]
    public void SearchTest()
    {
      var docStore = new Raven.Client.Document.DocumentStore { Url = "http://localhost:8080", DefaultDatabase = "TestDB" };
      docStore.Initialize();
      RavenRepository repository = new RavenRepository(docStore);
      ProductsController target = new ProductsController(repository); // TODO: Initialize to an appropriate value
      string searchStr = "Acer*";
      ActionResult actual;
      actual = target.Search(searchStr);
      Assert.IsNotNull(actual); //TODO: Improve assert here

    }
  }
}
