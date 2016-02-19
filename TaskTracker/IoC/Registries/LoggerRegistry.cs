using Microsoft.Practices.Unity;
using TaskTracker.Logging;

namespace TaskTracker.IoC.Registries
{
    public class LoggerRegistry : IUnityRegistry
    {
        public IUnityContainer ConfigureContainer(IUnityContainer container)
        {
            container.RegisterType<ICustomLogger, Log4NetFileLogger>();
            return container;
        }
    }
}