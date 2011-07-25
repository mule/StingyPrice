using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StingyPriceDAL.Models {
 public class StoreSearch
 {
   public DateTime Created { get; set; }
   public Store Store { get; set; } 
   public CategoryTree Categories { get; set; }

 }
}
