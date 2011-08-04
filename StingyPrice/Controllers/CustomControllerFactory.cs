using System;
using System.Web;
using System.Web.Mvc;
using Raven.Client.Embedded;
using StingyPriceDAL.Repositories;

namespace StingyPrice.Controllers
{
    public class CustomControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null) return base.GetControllerInstance(requestContext,controllerType);

            var docStore = HttpContext.Current.Application["DocumentStore"] as EmbeddableDocumentStore;
            var repository = new RavenRepository( docStore );

            return Activator.CreateInstance(controllerType, repository) as IController;
        }
    }
}