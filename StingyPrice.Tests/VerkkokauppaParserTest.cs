using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HtmlAgilityPack;
using StingyPrice.DataAcquisition.Parsers;
using StingyPrice.DataAcquisition.Parsers.Verkkokauppa;

namespace StingyPrice.Tests {


  /// <summary>
  ///This is a test class for VerkkokauppaParserTest and is intended
  ///to contain all VerkkokauppaParserTest Unit Tests
  ///</summary>
  [TestClass()]
  public class VerkkokauppaParserTest {


    private TestContext testContextInstance;

    private int categoryCount = 0;
    private int productCount = 0;

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
    ///A test for ParseMainpage
    ///</summary>
    [TestMethod()]
    [DeploymentItem(@".\TestData\verkkokauppa.htm")]
    public void ParseMainpageTest() {
      VerkkokauppaParser target = new VerkkokauppaParser();
      HtmlDocument document = new HtmlDocument();
      target.FoundCategory += new EventHandler<DataAcquisition.Parsers.ParserEventArgs>(target_FoundCategory);
      document.Load("verkkokauppa.htm");
      target.ParseMainpage(document);


      Assert.IsTrue(categoryCount == 8);
    }

    private void target_FoundCategory(object sender, ParserEventArgs e) {
      Trace.WriteLine(String.Format("Category found: {0} {1}", e.CategoryName, e.CategoryLink));
      categoryCount++;

    }

    /// <summary>
    ///A test for ParseCategoryPage
    ///</summary>
    [TestMethod()]
    [DeploymentItem(@".\TestData\productlist.htm")]
    public void ParsePage_product_list_found_test() {
      VerkkokauppaParser target = new VerkkokauppaParser();
      HtmlDocument result = new HtmlDocument();
      result.Load("productlist.htm");
      string parentCategory = "Pelikuullokkeet";
      target.FounndProduct += new EventHandler<ParserEventArgs>(target_FounndProduct);

      target.ParseCategoryPage(result, parentCategory);
      Assert.IsTrue(productCount > 10);


    }


    [TestMethod()]
    [DeploymentItem(@".\TestData\verkkokauppa_product.htm")]
    public void ParseProductPageTest() {
      VerkkokauppaParser target = new VerkkokauppaParser();
      HtmlDocument result = new HtmlDocument();
      result.Load("verkkokauppa_product.htm");

      var product = target.ParseProductPage(result, "TestiKategoria");

      Assert.IsNotNull(product);
      Assert.IsTrue(!String.IsNullOrEmpty(product.Name));
      Assert.IsTrue(product.Price!=Double.NaN);
      






    }



    void target_FounndProduct(object sender, ParserEventArgs e) {
      productCount++;
    }
  }
}
