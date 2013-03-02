using FfCmS.Code.Model;

namespace FfCmS.Code.Persistence
{
    public interface IRepository<TType>
    {
        Page<TType> List();
        TType SaveOrUpdate(TType item);
        TType Retrieve(string id);
    }
}