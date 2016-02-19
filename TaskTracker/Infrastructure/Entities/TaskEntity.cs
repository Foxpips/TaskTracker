using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTracker.Infrastructure.Entities
{
    [Table("Tasks")]
    public class TaskEntity : IEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("TaskList")]
        public int TaskListEntityId { get; set; }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual TaskListEntity TaskList{ get; set; }
    }
}