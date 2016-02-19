using Microsoft.Practices.Unity;

namespace TaskTracker.IoC.Registries
{
    public interface IUnityRegistry
    {
        IUnityContainer ConfigureContainer(IUnityContainer container);
    }
}