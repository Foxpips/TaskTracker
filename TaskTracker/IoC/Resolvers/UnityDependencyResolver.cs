using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace TaskTracker.IoC.Resolvers
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private readonly IUnityContainer _currentContainer;

        public UnityDependencyResolver(IUnityContainer currentContainer)
        {
            _currentContainer = currentContainer;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType.IsInterface || serviceType.IsAbstract)
            {
                return null;
            }

            return _currentContainer.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Enumerable.Empty<object>();
        }
    }
}