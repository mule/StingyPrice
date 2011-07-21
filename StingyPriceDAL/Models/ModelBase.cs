using StingyPrice.DAL.Models;

namespace StingyPriceDAL.Models
{
    public abstract class ModelBase : IModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}