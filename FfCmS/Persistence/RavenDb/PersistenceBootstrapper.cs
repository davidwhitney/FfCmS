using FfCmS.Model;
using Ninject;
using Raven.Abstractions.Util;
using Raven.Client;
using Raven.Client.Embedded;

namespace FfCmS.Persistence.RavenDb
{
    public class PersistenceBootstrapper : IPersistenceBootstrapper 
    {
        public void OnApplicationStart(IKernel kernel)
        {
            kernel.Bind<IDocumentStore>().ToMethod(x => new EmbeddableDocumentStore
                {
                    DataDirectory = "App_Data",
                    //UseEmbeddedHttpServer = true
                }).InSingletonScope();

            var store = kernel.Get<IDocumentStore>();

            store.Initialize();
            store.Conventions.RegisterIdConvention<ContentItem>(
                (dbname, commands, item) => "ContentStores/" + item.ContentStoreId + "/" + item.Id);
            store.Conventions.RegisterAsyncIdConvention<ContentItem>(
                (dbname, commands, item) => new CompletedTask<string>("ContentStores/" + item.ContentStoreId + "/" + item.Id));


            store.Conventions.RegisterIdConvention<ContentStoreForCreation>(
                (dbname, commands, item) => "IContentStore/" + item.Id);
            store.Conventions.RegisterAsyncIdConvention<ContentStoreForCreation>(
                (dbname, commands, item) => new CompletedTask<string>("IContentStore/" + item.Id));

            store.Conventions.RegisterIdConvention<ContentStore>(
                (dbname, commands, item) => "IContentStore/" + item.Id);
            store.Conventions.RegisterAsyncIdConvention<ContentStore>(
                (dbname, commands, item) => new CompletedTask<string>("IContentStore/" + item.Id));


            kernel.Bind<IRepository<IContentStore>>().To<ContentStoreRepository>();

            kernel.Bind<IDocumentSession>()
                  .ToMethod(x => x.Kernel.Get<IDocumentStore>().OpenSession());

        }

        public void InRequestScope(IKernel kernel)
        {
            //kernel.Bind<IDocumentSession>()
            //      .ToMethod(x => x.Kernel.Get<IDocumentStore>().OpenSession());
        }

        public void OnRequestEnd(IKernel kernel)
        {
            var docSession = kernel.Get<IDocumentSession>();
            docSession.Dispose();
        }
    }
}
