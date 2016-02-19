using System.Data.Entity;
using TaskTracker.Infrastructure.Entities;

namespace TaskTracker.Infrastructure.Contexts
{
    public class TaskContext : ContextBase
    {
        public DbSet<TaskEntity> Tasks { get; set; }
    }
}