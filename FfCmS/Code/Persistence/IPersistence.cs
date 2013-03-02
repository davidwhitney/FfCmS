using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FfCmS.Code.Persistence
{
    public interface IPersistence
    {
        TType SaveOrUpdate<TType>(TType item);
        TType Retrieve<TType>(string id);
    }
}