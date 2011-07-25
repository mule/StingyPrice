using StingyPrice.DAL.Models;

namespace StingyPriceDAL.Models {
  public class CategoryTree : IModel {
    public string Id { get; set; }
    public Category Root { get; set; }

      public Category FindCategory(string name)
      {
          return Root.FindCategory(name);


      }

      public override string ToString()
      {
          return Root.ToString();
      }

  }
}