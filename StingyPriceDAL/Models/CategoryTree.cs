using StingyPrice.DAL.Models;

namespace StingyPriceDAL.Models {
  public class CategoryTree : IModel {
    public string Id { get; set; }
    public Category Root { get; set; }

  }
}