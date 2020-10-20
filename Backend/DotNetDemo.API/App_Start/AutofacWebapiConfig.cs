using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using DotNetDemo.Business.Interfaces.Services;
using DotNetDemo.Business.Services;
using DotNetDemo.Business.UoW;
using DotNetDemo.Database.Domain;

namespace DotNetDemo.API
{
    public static class AutofacWebapiConfig
    {
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<DotNetDemoEntities>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
			builder.RegisterType<PackageService>().As<IPackageService>().InstancePerLifetimeScope();
            builder.RegisterType<GroupService>().As<IGroupService>().InstancePerLifetimeScope();
            builder.RegisterType<TagService>().As<ITagService>().InstancePerLifetimeScope();


            //Set the dependency resolver to be Autofac.  
            var container = builder.Build();

            return container;
        }

    }

}