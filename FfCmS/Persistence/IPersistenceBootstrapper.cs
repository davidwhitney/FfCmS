using Ninject;

namespace FfCmS.Persistence
{
    public interface IPersistenceBootstrapper
    {
        void OnApplicationStart(IKernel kernel);
        void InRequestScope(IKernel container);
        void OnRequestEnd(IKernel container);
    }
}
