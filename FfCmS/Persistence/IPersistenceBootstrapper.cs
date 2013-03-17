using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FfCmS.Core.Persistence
{
    public interface IPersistenceBootstrapper
    {
        void OnApplicationStart();
    }
}
