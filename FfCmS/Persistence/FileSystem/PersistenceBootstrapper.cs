using System;
using System.Web;
using FfCmS.Model;
using Ninject;

namespace FfCmS.Persistence.FileSystem
{
    public class PersistenceBootstrapper : IPersistenceBootstrapper 
    {
        public void OnApplicationStart(IKernel kernel)
        {
            kernel.Bind<IRepository<IContentStore>>().To<ContentStoreRepository>();
            kernel.Bind<string>()
                  .ToMethod(x => HttpContext.Current.Server.MapPath("~/App_Data"))
                  .WhenInjectedInto(typeof (ContentStoreRepository));
        }

        public void InRequestScope(IKernel container)
        {
        }

        public void OnRequestEnd(IKernel container)
        {
        }
    }
}
