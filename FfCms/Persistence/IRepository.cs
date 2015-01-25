namespace FfCms.Persistence
{
    public interface IRepository<TType>
    {
        Page<TType> List();
        TType SaveOrUpdate(TType item);
        TType Retrieve(string id);
    }
}