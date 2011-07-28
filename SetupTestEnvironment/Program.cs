using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml;
using Raven.Client;
using StingyPrice.DataAcquisition;
using StingyPrice.DataAcquisition.Parsers.Verkkokauppa;
using StingyPriceDAL.Models;

namespace SetupTestEnvironment
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var documentStore = new Raven.Client.Document.DocumentStore { Url = "http://localhost:8080", DefaultDatabase = "TestDB" };
            documentStore.Initialize();
            var session = documentStore.OpenSession();


            FetchTestStoreDataToDb(session);


        }



        public static void FetchTestStoreDataToDb(IDocumentSession session)
        {
            var browser = new StoreBrowser();

            browser.BrowseStore(new VerkkokauppaParser(), new Store(){MainPageUrl = @"http://www.verkkokauppa.com", Name = "Verkkokauppa"});

            session.Store(browser.SearchResult);




        }


        public static void StoreCategoryDataToDb(IDocumentSession session)
        {
            var doc = new XmlDocument();
            var categoryNameList = new List<string>();
            var catTree = new CategoryTree() { Root = new Category() { Name = "Root", SubCategories = new List<Category>() } };




            doc.Load(@"kategoriat.xml");

            var nodes = doc.SelectNodes(@"//dbo.Tuote[SisaltaaKategorioita='1' ]");

            foreach (XmlNode node in nodes)
            {

                if (node.InnerText.Split(' ')[0].EndsWith("1"))
                    categoryNameList.Add(node.InnerText.TrimEnd('1'));
            }


            foreach (string catName in categoryNameList)
            {
                Trace.WriteLine(catName);
                catTree.Root.SubCategories.Add(new Category() { Name = catName });

            }

            session.Store(catTree);
            session.SaveChanges();
        }

    }

}
