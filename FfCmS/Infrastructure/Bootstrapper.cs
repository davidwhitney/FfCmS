using System;
using System.IO.Abstractions;
using System.Linq;
using FfCmS.Features.Persistence;
using FfCmS.Model;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Ninject;
using Ninject;
using Ninject.Extensions.Conventions;

namespace FfCmS.Infrastructure
{
    public class Bootstrapper : NinjectNancyBootstrapper
    {
        protected override void ApplicationStartup(IKernel container, IPipelines pipelines)
        {
            // No registrations should be performed in here, however you may
            // resolve things that are needed during application startup.
        }

        protected override void ConfigureApplicationContainer(IKernel existingContainer)
        {
            existingContainer.Bind<IRepository<ContentItem>>().To<FileSystemContentRepository>();
            existingContainer.Bind<IRepository<ContentStore>>().To<FileSystemContentStoreRepository>();
            existingContainer.Bind(scanner => scanner.FromAssemblyContaining<IFileSystem>().Select(IsServiceType).BindDefaultInterfaces());
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