using System;
using System.Linq;
using FfCmS.Server.Model;

namespace FfCmS.Server.Persistence.RavenDb
{
    public class ContentStoreRepository : IRepository<IContentStore>
    {
        public Page<IContentStore> List()
        {
            throw new NotImplementedException();
        }

        public IContentStore SaveOrUpdate(IContentStore item)
        {
            throw new NotImplementedException();
        }

        public IContentStore Retrieve(string id)
        {
            return List().FirstOrDefault(x => x.Id == id);
        }
    }
}