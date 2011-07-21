using System.Linq;
using System.Web.Mvc;
using StingyPrice.Models.ViewModels;
using StingyPriceDAL.Models;
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
            var catTree = _repository.All<CategoryTree>().FirstOrDefault();
           
            var vm = new CategoriesViewModel();
            vm.MainCategoryNames = catTree.Root.SubCategories.Select(c => c.Name).ToList();


           

            return View(vm);
        }

    }
}
