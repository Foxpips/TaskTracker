using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTracker.Infrastructure.Entities
{
    [Table("TaskList")]
    public class TaskListEntity : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        private List<TaskEntity> _tasks;

        public virtual List<TaskEntity> Tasks
        {
            get { return _tasks ?? (_tasks = new List<TaskEntity>()); }
        }
    }
}