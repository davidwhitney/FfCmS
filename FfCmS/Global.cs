using System;
using System.IO.Abstractions;
using System.Linq;
using System.Web;
using FfCmS.Core.Model;
using FfCmS.Core.Persistence;
using FfCmS.Persistence.FileSystem;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Ninject;
using Ninject;
using Ninject.Extensions.Conventions;

namespace FfCmS
{
    public class Global : NinjectNancyBootstrapper
    {
        protected override void ApplicationStartup(IKernel container, IPipelines pipelines)
        {
            ConfigureViewLocations();
        }

        protected override void ConfigureApplicationContainer(IKernel existingContainer)
        {
            existingContainer.Bind(scanner => scanner.FromAssemblyContaining<IFileSystem>().Select(IsServiceType).BindDefaultInterfaces());

            existingContainer.Bind<IRepository<IContentStore>>().To<ContentStoreRepository>();
            existingContainer.Bind<string>()
                             .ToMethod(x => HttpContext.Current.Server.MapPath("~/App_Data"))
                             .WhenInjectedInto(typeof(ContentStoreRepository));
        }

        protected override void ConfigureRequestContainer(IKernel container, NancyContext context)
        {
            // Perform registrations that should have a request lifetime
        }

        protected override void RequestStartup(IKernel container, IPipelines pipelines, NancyContext context)
        {
            // No registrations should be performed in here, however you may
            // resolve things that are needed during request startup.
        }
        
        private void ConfigureViewLocations()
        {
            Conventions.ViewLocationConventions.Add(
                (viewName, model, context) => string.Concat("../../Views/", context.ModuleName, "/", viewName));
            Conventions.ViewLocationConventions.Add(
                (viewName, model, context) => string.Concat("Views/", context.ModuleName, "/", viewName));

            Conventions.ViewLocationConventions.Add((viewName, model, context) =>
            {
                Type type = model.GetType();
                var firstInterface = type.GetInterfaces().FirstOrDefault();
                return firstInterface != null
                           ? string.Concat("Views/", context.ModuleName, "/", firstInterface.Name)
                           : string.Concat("Views/", context.ModuleName, "/", Guid.NewGuid());
            });

            Conventions.ViewLocationConventions.Add((viewName, model, context) =>
            {
                Type type = model.GetType();
                var isGeneric = type.IsGenericType;

                var nameToLookup = viewName;
                if (isGeneric)
                {
                    var name = type.GetGenericArguments()[0].Name;
                    nameToLookup = nameToLookup.Replace("`1", "[" + name + "]");
                }

                return string.Concat("Views/", context.ModuleName, "/", nameToLookup);
            });
        }

        private static bool IsServiceType(Type type)
        {
            return type.IsClass && type.GetInterfaces().Any(intface => intface.Name == "I" + type.Name);
        }
    }
}