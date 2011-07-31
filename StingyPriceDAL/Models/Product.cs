using StingyPrice.DAL.Models;
using StingyPrice.Models;

namespace StingyPriceDAL.Models {
  public class Product : IModel {
      public string Id { get; set; }
      public string Name { get; set; }
      public Store Store { get; set; }
      public double Price { get; set; }
      public Category Category { get; set; }
      public ProductGroup ProductGroup { get; set; }


      public override string ToString()
      {
        var prodStr = string.Format("Name: {0} Price: {1}", Name, Price);
        return prodStr;
      }

  }
}