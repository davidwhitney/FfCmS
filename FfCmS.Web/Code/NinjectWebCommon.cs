using FfCmS.Code.Model;
using FfCmS.Code.Persistence;
using FfCmS.Controllers;
using Ninject;

namespace FfCmS.App_Start
{

    public static class NinjectWebCommon 
    {

        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            
            RegisterServices(kernel);

            ContentApiController.InitStorage = () => kernel.Get<Storage>();
            StoresApiController.InitStorage = () => kernel.Get<Storage>();
    
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IRepository<ContentItem>>().To<FileSystemContentRepository>();
            kernel.Bind<IRepository<ContentStore>>().To<FileSystemContentStoreRepository>();
        }        
    }
}
