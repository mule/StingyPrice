using System.Web.Mvc;
using StingyPriceDAL.Repositories;

namespace StingyPrice.Controllers
{
    public class CategoriesController : Controller
    {
      private IRepository _repository;

      public CategoriesController()
      {
        
      }

      public CategoriesController(IRepository repository)
      {
        _repository = repository;

      }
        //
        // GET: /Categories/

        public ActionResult Index()
        {
          

            return View();
        }

    }
}
