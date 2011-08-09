using System.Linq;
using System.Web.Mvc;
using StingyPrice.DAL.Models;
using StingyPrice.DAL.Repositories;

namespace StingyPrice.Controllers
{
    public class CategoriesController : Controller
    {
        private IRepository _repository;

        public CategoriesController()
        {


        }

        public CategoriesController(IRepository repository) : this()
        {
         
            _repository = repository;

            var catTree = _repository.All<CategoryTree>().FirstOrDefault();



            if (catTree != null)
              ViewBag.CategoryTree = catTree.Root;
        }
        //
        // GET: /Categories/
         
        public ActionResult Index()
        {


            

            if (ValidateRequest)
            {


            }
            else
            {
                //TODO: Go to error page here

            }





            return View();
        }

     



    }
}
