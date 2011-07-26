using System.Collections.Generic;
using System.Linq;
using System.Text;
using StingyPrice.DAL.Models;

namespace StingyPriceDAL.Models
{
    public class Category : IModel
    {
      
      public string Id { get; set; }
      public string Name { get; set; }
      public ICollection<Category> SubCategories { get; set; }
        public ICollection<Product> Products { get; set; }

        public Category()
        {
            SubCategories = new List<Category>();
            
        }

        public Category FindCategory(string name)
        {
            if (Name.ToLower() == name.ToLower())
                return this;
            else
            {
                return SubCategories.Select(subCategory => subCategory.FindCategory(name)).FirstOrDefault(sub => sub != null);
            }

         

        }

        public void AddSubCategory(Category category)
        {
          SubCategories.Add(category);

        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("Categoryname: {0}", Name));

            foreach (Category subCategory in SubCategories)
            {
                sb.AppendLine(subCategory.ToString());
            }

            return sb.ToString();
        }
    
       

    }
}