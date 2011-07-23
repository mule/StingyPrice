using System.Diagnostics;
using StingyPrice.Parsers.Verkkokauppa;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HtmlAgilityPack;

namespace StingyPrice.Tests
{
    
    
    /// <summary>
    ///This is a test class for VerkkokauppaParserTest and is intended
    ///to contain all VerkkokauppaParserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VerkkokauppaParserTest
    {


        private TestContext testContextInstance;

        private int categoryCount = 0;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
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
        public void ParseMainpageTest()
        {
            VerkkokauppaParser target = new VerkkokauppaParser(); 
            HtmlDocument document = new HtmlDocument();
            target.FoundCategory += new VerkkokauppaParser.ParserEventHandler(target_FoundCategory);
            document.Load("verkkokauppa.htm");
            target.ParseMainpage(document);

           
           Assert.IsTrue(categoryCount==8);
        }

        void target_FoundCategory(object sender, VerkkokauppaParser.ParserEventArgs args)
        {
            Trace.WriteLine(String.Format("Category found: {0} {1}",args.CategoryName, args.CategoryLink));
            categoryCount++;
        }
    }
}
