using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using TP07MVC.Data;
using TP07MVC.Logic;

namespace TP08WebAPI.WebAPI
{
    public class IoCConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<NorthwindContext>().InstancePerRequest();
            builder.RegisterType<ShippersLogic>().As<IShippersLogic>().InstancePerRequest();
            builder.RegisterType<CategoriesLogic>().As<ICategoriesLogic>().InstancePerRequest();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}