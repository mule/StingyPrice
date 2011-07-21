using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StingyPrice.DAL.Models;

namespace StingyPrice.Models
{
    public class Category : IModel
    {
      
      public string Id { get; set; }
      public string Name { get; set; }
      public IEnumerable<Category> SubCategories { get; set; }
    


    }
}