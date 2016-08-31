using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Yelo.Api.App_Start;
using Yelo.BusinessServices;
using Yelo.BusinessServices.Interfaces;
using Yelo.DataModel.UnitOfWork;

namespace Yelo.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = new UnityContainer();
            container.RegisterType<IUserServices, UserServices>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IProductServices, ProductServices>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());  
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
