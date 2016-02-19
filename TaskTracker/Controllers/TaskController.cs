using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TaskTracker.Helpers;
using TaskTracker.Infrastructure.Entities;
using TaskTracker.Infrastructure.Repositories;
using TaskTracker.Logging;

namespace TaskTracker.Controllers
{
    public class TaskController : Controller
    {
        private readonly IRepository<DbContext, TaskEntity> _taskRepository;
        private readonly IRepository<DbContext, TaskListEntity> _taskListRepository;


        public int TaskListId
        {
            get { return (int) Session["CurrentId"]; }
            set { Session["CurrentId"] = value; }
        }

        public TaskController(ICustomLogger logger, IRepository<DbContext, TaskListEntity> listrepository,
            IRepository<DbContext, TaskEntity> repository)
        {
            _taskRepository = repository;
            _taskListRepository = listrepository;
        }

        public ActionResult Index(int id)
        {
            TaskListId = id;
            return View();
        }

        public ActionResult Create(TaskEntity newTask)
        {
            _taskListRepository.Connect(database =>
            {
                var listEntity = database.Set<TaskListEntity>().Find(TaskListId);
                newTask.TaskList = listEntity;
                listEntity.Tasks.Add(newTask);
                _taskListRepository.AddOrUpdate(listEntity);
            });
            //            _taskListRepository.AddOrUpdate(taskListEntity);
            
            _taskRepository.AddOrUpdate(newTask);
            return View();
        }

        public ActionResult ActiveTasks(int id)
        {
            var taskEntities = _taskRepository.List().Where(entity => entity.TaskListEntityId == id);
            return View(taskEntities);
        }
    }
}