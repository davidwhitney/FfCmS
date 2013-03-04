using System;
using System.IO.Abstractions;
using System.Linq;
using System.Web;
using FfCmS.Features.Persistence;
using FfCmS.Features.Persistence.FileSystem;
using FfCmS.Model;
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
            Conventions.ViewLocationConventions.Add((viewName, model, context) => string.Concat("../../Views/", context.ModuleName, "/", viewName));
            Conventions.ViewLocationConventions.Add((viewName, model, context) => string.Concat("Views/", context.ModuleName, "/", viewName));
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