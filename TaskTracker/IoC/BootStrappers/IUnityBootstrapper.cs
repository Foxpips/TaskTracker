using System;
using Microsoft.Practices.Unity;

namespace TaskTracker.IoC.BootStrappers
{
    public interface IUnityBootstrapper
    {
        IUnityContainer CreateContainer(Type[] types);
    }
}