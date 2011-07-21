using System.Collections.Generic;
using StingyPrice.DAL.Models;

namespace StingyPriceDAL.Models
{
    public class Category : IModel
    {
      
      public string Id { get; set; }
      public string Name { get; set; }
      public ICollection<Category> SubCategories { get; set; }
    


    }
}