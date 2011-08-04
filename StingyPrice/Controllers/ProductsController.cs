using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StingyPrice.Models.ViewModels;
using StingyPriceDAL.Models;
using StingyPriceDAL.Repositories;

namespace StingyPrice.Controllers
{
    public class ProductsController : Controller
    {
      private IRepository _repository
        ;

      public ProductsController()
      {
        
      }

              public ProductsController(IRepository repository) : this()
        {
         
            _repository = repository;

            var catTree = _repository.All<CategoryTree>().FirstOrDefault();



            if (catTree != null)
              ViewBag.CategoryTree = catTree.Root;
        }
        //
        // GET: /Products/

        public ActionResult Index()
        {
            return View();
        }

     
        public ActionResult Search(string searchStr) {
          var vm = new ProductSearchViewModel();

          var storeProductSearch = _repository as RavenRepository;

          if (storeProductSearch != null) {
            var storeProductGroups = storeProductSearch.SearchStoreProductGroups(searchStr);

            if (storeProductGroups != null)
              vm.StoreProducts = storeProductGroups;

          }



          return View(vm);


        }
    }
}
