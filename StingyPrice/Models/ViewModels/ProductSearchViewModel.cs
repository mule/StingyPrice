using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StingyPriceDAL.Models;

namespace StingyPrice.Models.ViewModels {
  public class ProductSearchViewModel
  {
    public Dictionary<string, List<Product>> StoreProducts { get; set; }

    public ProductSearchViewModel()
    {
      StoreProducts = new Dictionary<string, List<Product>>();
    }




  }
}