using System.Data.Entity;
using System.Linq;
using TaskTracker.Helpers;
using TaskTracker.Infrastructure.Contexts;
using TaskTracker.Infrastructure.Entities;

namespace TaskTracker.Infrastructure.Repositories
{
    public class TaskRepository : RepositoryBase<TaskListContext, TaskEntity>
    {
        public DbSet<TaskEntity> Tasks
        {
            get { return Connect(database => database.Tasks); }
        }

        public int Count()
        {
            return Connect(database => database.Tasks.Count());
        }

        public void Truncate()
        {
            Connect(data => data.Tasks.ForEach(x => data.Tasks.Remove(x)));
        }
    }
}