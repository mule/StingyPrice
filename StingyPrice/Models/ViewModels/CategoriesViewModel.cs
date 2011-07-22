using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StingyPriceDAL.Models;

namespace StingyPrice.Models.ViewModels
{
    public class CategoriesViewModel
    {
      public Dictionary<string, List<string>> CategoryNameDictionary;

      public CategoriesViewModel()
      {
        CategoryNameDictionary = new Dictionary<string, List<string>>();
      }



      public void BuildNamesDictionary(Category rootCategory)
      {
        List<string> names = new List<string>();
        foreach (Category subCategory in rootCategory.SubCategories)
        {
          if (subCategory.SubCategories != null)
          {
            names = subCategory.SubCategories.Select(scat => scat.Name).ToList();
           

          }
    
            CategoryNameDictionary.Add(subCategory.Name, names);
            names.Clear();
          
        }


      }

    }
}