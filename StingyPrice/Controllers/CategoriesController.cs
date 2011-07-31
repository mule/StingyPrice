using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StingyPrice.Models.ViewModels;
using StingyPriceDAL.Models;
using StingyPriceDAL.Repositories;
using Telerik.Web.Mvc;

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

            var vm = new CategoriesViewModel() {Root = catTree.Root};

            if (catTree != null)
                ViewBag.CategoryTree = catTree.Root;

            

            if (ValidateRequest)
            {


            }
            else
            {
                //TODO: Go to error page here

            }





            return View(vm);
        }

    }
}
