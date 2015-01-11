using FfCmS.Server.Model;

namespace FfCmS.Server.Persistence
{
    public interface IRepository<TType>
    {
        Page<TType> List();
        TType SaveOrUpdate(TType item);
        TType Retrieve(string id);
    }
}