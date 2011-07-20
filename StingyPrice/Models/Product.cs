using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StingyPrice.Models;

namespace StingyPrice.DAL.Models {
  public class Product : IModel {
      public string Id { get; set; }
      public string Name { get; set; }
      public Store Store { get; set; }
      public double Price { get; set; }
      public Category Category { get; set; }
      public ProductGroup ProductGroup { get; set; }

  }
}