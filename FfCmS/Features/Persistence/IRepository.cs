using FfCmS.Model;

namespace FfCmS.Features.Persistence
{
    public interface IRepository<TType>
    {
        Page<TType> List();
        TType SaveOrUpdate(TType item);
        TType Retrieve(string id);
    }
}