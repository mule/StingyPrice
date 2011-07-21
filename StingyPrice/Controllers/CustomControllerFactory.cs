using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raven.Client.Document;
using StingyPrice.DAL.Repositories;

namespace StingyPrice.Controllers
{
    public class CustomControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null) return base.GetControllerInstance(requestContext,controllerType);

            var docStore = HttpContext.Current.Application["DocumentStore"] as DocumentStore;
            var repository = new RavenRepository( docStore );

            return Activator.CreateInstance(controllerType, repository) as IController;
        }
    }
}