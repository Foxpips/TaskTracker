using System.Data.Entity;
using Microsoft.Practices.Unity;
using TaskTracker.Infrastructure.Entities;
using TaskTracker.Infrastructure.Repositories;

namespace TaskTracker.IoC.Registries
{
    public class DataAccessRegistry : IUnityRegistry
    {
        public IUnityContainer ConfigureContainer(IUnityContainer container)
        {
            container.RegisterType<IRepository<DbContext, TaskListEntity>, TaskListRepository>();
            return container.RegisterType<IRepository<DbContext, TaskEntity>, TaskRepository>();
        }
    }
}