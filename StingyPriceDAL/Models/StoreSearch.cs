using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StingyPrice.DAL.Models;

namespace StingyPriceDAL.Models {
 public class StoreSearch : IModel
 {
   public DateTime Created { get; set; }
   public Store Store { get; set; } 
   public CategoryTree Categories { get; set; }


   public string Id { get; set; }
 }
}
