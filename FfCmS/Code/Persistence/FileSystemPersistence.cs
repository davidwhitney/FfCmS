using System;

namespace FfCmS.Code.Persistence
{
    public class FileSystemPersistence : IPersistence
    {
        public TType SaveOrUpdate<TType>(TType item)
        {
            throw new NotImplementedException();
        }

        public TType Retrieve<TType>(string id)
        {
            throw new NotImplementedException();
        }
    }
}