using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StingyPrice.Models.ViewModels;
using StingyPriceDAL;
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
