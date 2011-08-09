using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Raven.Client;
using Raven.Client.Document;
using StingyPrice.DAL.Models;
using StingyPrice.DataAcquisition.Parsers;
using StingyPrice.DataAcquisition.Parsers.Verkkokauppa;

namespace StingyPrice.DataAcquisition {
  public class DataCollector {
    private StoreSearch _currentSearch;
    private Parser _parser;
    private StoreBrowser _browser;
    private DocumentStore _documentstore;
    private IDocumentSession _session;
    public ICollection<Product> Products { get; set; }


    public DataCollector() {
      _documentstore = new DocumentStore() { DefaultDatabase = "TestDB" };
      Products = new Collection<Product>();


    }


    public void CollectStoreData(Store store) {

      _currentSearch = new StoreSearch() { Categories = new List<string>(), Created = DateTime.Now, Store = store };
      _parser = new VerkkokauppaParser();


      _parser.ProductParsed +=new EventHandler<ParserEventArgs>(_parser_ProductParsed);


      _browser = new StoreBrowser();
      _browser.BrowseStore(_parser,store);




    }

    void _parser_ProductParsed(object sender, ParserEventArgs e) {
      Products.Add(e.Product);



    }


  }
}
