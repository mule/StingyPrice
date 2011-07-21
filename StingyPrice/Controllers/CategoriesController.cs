using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StingyPrice.DAL.Repositories;

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
