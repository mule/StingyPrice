using StingyPriceDAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Raven.Client.Document;
using StingyPriceDAL.Models;
using System.Collections.Generic;

namespace StingyPrice.Tests
{
    
    
    /// <summary>
    ///This is a test class for TextSearchGroupperTest and is intended
    ///to contain all TextSearchGroupperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TextSearchGroupperTest
    {


        private TestContext testContextInstance;

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
        ///A test for SearchGroups
        ///</summary>
        [TestMethod()]
        public void SearchGroupsTest()
        {
            var documentStore = new Raven.Client.Document.DocumentStore { Url = "http://localhost:8080", DefaultDatabase = "TestDB" };
            documentStore.Initialize();
         

            TextSearchGroupper target = new TextSearchGroupper(documentStore); 
            string searchStr = "Acer*ICONIA";
       
            ICollection<Product> actual;
            actual = target.SearchGroups(searchStr);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count==2);

        }
    }
}
