using System;
using Microsoft.Practices.Unity;
using TaskTracker.IoC.Registries;

namespace TaskTracker.IoC.BootStrappers
{
    public class UnityBootstrapper : IUnityBootstrapper
    {
        private IUnityContainer Container { get; set; }

        public UnityBootstrapper(IUnityContainer container = null)
        {
            Container = container ?? new UnityContainer();
        }

        public IUnityContainer CreateContainer(Type[] exportedTypes)
        {
            foreach (var type in exportedTypes)
            {
                if (typeof (IUnityRegistry).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                {
                    ((IUnityRegistry) Activator.CreateInstance(type)).ConfigureContainer(Container);
                }
            }
            return Container;
        }
    }
}


//            Container.RegisterTypes(AllClasses.FromLoadedAssemblies(), WithMappings.FromMatchingInterface,
//                WithName.Default);