using FfCmS.Model;
using Ninject;
using Raven.Abstractions.Util;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Database.Server;

namespace FfCmS.Persistence.RavenDb
{
    public class PersistenceBootstrapper : IPersistenceBootstrapper 
    {
        public void OnApplicationStart(IKernel kernel)
        {
            NonAdminHttp.EnsureCanListenToWhenInNonAdminContext(8080);

            var store =
                new EmbeddableDocumentStore
                    {
                        ConnectionStringName = "RavenDB",
                        UseEmbeddedHttpServer = true
                    };
            store.Configuration.Port = 8079;
            store.Configuration.AnonymousUserAccessMode = AnonymousUserAccessMode.All;
            
            store.Conventions.RegisterIdConvention<ContentStore>(
                (dbname, commands, item) => "ContentStore/" + item.Id);
            store.Conventions.RegisterAsyncIdConvention<ContentStore>(
                (dbname, commands, item) => new CompletedTask<string>("ContentStore/" + item.Id));

            store.Conventions.RegisterIdConvention<ContentItem>(
                (dbname, commands, item) => "ContentStore/" + item.ContentStoreId + "/" + item.Id);
            store.Conventions.RegisterAsyncIdConvention<ContentItem>(
                (dbname, commands, item) => new CompletedTask<string>("ContentStore/" + item.ContentStoreId + "/" + item.Id));

            kernel.Bind<IDocumentStore>().ToMethod(x => store).InSingletonScope();
            store.Initialize();


            kernel.Bind<IRepository<IContentStore>>().To<ContentStoreRepository>();
            
            kernel.Bind<IDocumentSession>()
                  .ToMethod(x => x.Kernel.Get<IDocumentStore>().OpenSession());

            kernel.Bind<IContentStoreQueries>().To<ContentStoreQueries>();

        }

        public void InRequestScope(IKernel kernel)
        {
            kernel.Rebind<IDocumentSession>().ToMethod(x => x.Kernel.Get<IDocumentStore>().OpenSession());
        }

        public void OnRequestEnd(IKernel kernel)
        {
            var docSession = kernel.Get<IDocumentSession>();
            docSession.SaveChanges();
            docSession.Dispose();
        }
    }
}
