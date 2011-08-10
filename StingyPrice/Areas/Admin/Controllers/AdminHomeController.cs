using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StingyPriceDAL.Repositories;

namespace StingyPrice.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
      private IRepository _repository;


      public AdminHomeController(IRepository repository)
      {
        _repository = repository;

      }
        //
        // GET: /Admin/Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
