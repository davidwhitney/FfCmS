using FfCmS.Model;
using FfCmS.Persistence;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Ninject;
using Ninject;

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
    }
}