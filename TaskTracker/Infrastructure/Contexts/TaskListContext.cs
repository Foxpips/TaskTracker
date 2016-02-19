using System.Data.Entity;
using TaskTracker.Infrastructure.Entities;

namespace TaskTracker.Infrastructure.Contexts
{
    public class TaskListContext : ContextBase
    {
        public DbSet<TaskListEntity> TaskList { get; set; }

        public DbSet<TaskEntity> Tasks { get; set; }
    }
}