using System.Data.Entity;
using System.Linq;
using TaskTracker.Helpers;
using TaskTracker.Infrastructure.Contexts;
using TaskTracker.Infrastructure.Entities;

namespace TaskTracker.Infrastructure.Repositories
{
    public class TaskListRepository : RepositoryBase<TaskListContext, TaskListEntity>
    {
        public DbSet<TaskListEntity> Tasks
        {
            get { return Connect(database => database.TaskList); }
        }

        public int Count()
        {
            return Connect(database => database.TaskList.Count());
        }

        public void Truncate()
        {
            Connect(data => data.TaskList.ForEach(x => data.TaskList.Remove(x)));
        }
    }
}