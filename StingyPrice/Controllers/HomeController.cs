using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StingyPrice.DAL.Repositories;

namespace StingyPrice.Controllers {
  public class HomeController : Controller
  {
    private IRepository _repository;

    public HomeController()
    {
      
    }
    public HomeController(RavenRepository repository)
    {
      _repository = repository;

    }
    public ActionResult Index() {
      ViewBag.Message = "Welcome to ASP.NET MVC!";

      return View();
    }

    public ActionResult About() {
      return View();
    }
  }
}
