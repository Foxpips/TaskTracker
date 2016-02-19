using System.Data.Entity;

namespace TaskTracker.Infrastructure.Contexts
{
    public class ContextBase : DbContext
    {
        public ContextBase() : base("TaskTrackerDb")
        {
        }
    }
}