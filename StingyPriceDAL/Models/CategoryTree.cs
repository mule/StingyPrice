using System.Collections.Generic;
using System.Diagnostics;
using StingyPrice.DAL.Models;

namespace StingyPrice.DAL.Models {
  public class CategoryTree : IModel {
    public string Id { get; set; }
    public Category Root { get; set; }

    public Category FindCategory(string name) {
      return Root.FindCategory(name);


    }

    public bool AddProduct(Product product, string categoryName) {
      var cat = FindCategory(categoryName);

      if (cat != null) {
        if (cat.Products == null)
          cat.Products = new List<Product>();
        cat.Products.Add(product);
        Trace.WriteLine(string.Format("Product {0} added to tree", product.Name));
        return true;

      }
      else {
        Trace.WriteLine(string.Format("Could not find category {0} for product {1}", categoryName, product.Name));
        return false;
      }


    }

    public override string ToString() {
      return Root.ToString();
    }

  }
}