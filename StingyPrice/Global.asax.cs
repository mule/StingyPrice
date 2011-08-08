using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Raven.Client.Embedded;
using Raven.Http;
using StingyPrice.Controllers;

namespace StingyPrice {
  // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
  // visit http://go.microsoft.com/?LinkId=9394801

  public class MvcApplication : System.Web.HttpApplication {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
      filters.Add(new HandleErrorAttribute());
    }

    public static void RegisterRoutes(RouteCollection routes) {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
          "Default", // Route name
          "{controller}/{action}/{id}", // URL with parameters
          new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
      );

    }

// ReSharper disable InconsistentNaming
    protected void Application_Start() {
// ReSharper restore InconsistentNaming
      AreaRegistration.RegisterAllAreas();
      
      RegisterGlobalFilters(GlobalFilters.Filters);
      RegisterRoutes(RouteTable.Routes);
    

      //var documentStore = new Raven.Client.Document.DocumentStore { Url = "http://localhost:8080", DefaultDatabase = "TestDB"};
        var documentStore = new EmbeddableDocumentStore {DataDirectory = @"~\App_Data", UseEmbeddedHttpServer = true, DefaultDatabase = "TestDB"};
        NonAdminHttp.EnsureCanListenToWhenInNonAdminContext(8080);
      documentStore.Initialize();
      Application["DocumentStore"] = documentStore;
      ControllerBuilder.Current.SetControllerFactory(typeof(CustomControllerFactory));
    }
  }
}