using System;
using System.IO.Abstractions;
using System.Linq;
using System.Web;
using FfCmS.Model;
using FfCmS.Persistence;
using FfCmS.Persistence.FileSystem;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Ninject;
using Nancy.TinyIoc;
using Ninject;
using Ninject.Extensions.Conventions;

namespace FfCmS.Infrastructure
{
    public class Bootstrapper : NinjectNancyBootstrapper
    {
        protected override void ApplicationStartup(IKernel container, IPipelines pipelines)
        {
            Conventions.ViewLocationConventions.Add((viewName, model, context) =>
                {
                    return string.Concat("../../Views/", context.ModuleName, "/", viewName);
                });
            Conventions.ViewLocationConventions.Add((viewName, model, context) =>
                {
                    return string.Concat("Views/", context.ModuleName, "/", viewName);
                });

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

        protected override void ConfigureApplicationContainer(IKernel existingContainer)
        {
            existingContainer.Bind(scanner => scanner.FromAssemblyContaining<IFileSystem>().Select(IsServiceType).BindDefaultInterfaces());

            existingContainer.Bind<IRepository<IContentStore>>().To<FileSystemContentStoreRepository>();
            existingContainer.Bind<string>()
                             .ToMethod(x => HttpContext.Current.Server.MapPath("~/App_Data"))
                             .WhenInjectedInto(typeof(FileSystemContentStoreRepository));
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

        private static bool IsServiceType(Type type)
        {
            return type.IsClass && type.GetInterfaces().Any(intface => intface.Name == "I" + type.Name);
        }
    }
}