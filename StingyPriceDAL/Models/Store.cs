using System.Collections.Generic;
using StingyPrice.DAL.Models;

namespace StingyPriceDAL.Models {
  public class Store : IModel
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string MainPageUrl { get; set; }
    //public ICollection<Product> Products { get; set; }


  }
}