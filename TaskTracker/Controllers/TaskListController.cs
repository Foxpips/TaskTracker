using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TaskTracker.Helpers;
using TaskTracker.Infrastructure.Entities;
using TaskTracker.Infrastructure.Repositories;
using TaskTracker.Logging;

namespace TaskTracker.Controllers
{
    public class TaskListController : Controller
    {
        private readonly IRepository<DbContext, TaskListEntity> _taskRepository;

        public TaskListController(ICustomLogger logger,
            IRepository<DbContext, TaskListEntity> repository)
        {
            _taskRepository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(TaskListEntity newTaskList)
        {
            _taskRepository.Add(newTaskList);
            return View("ActiveTaskList", _taskRepository.List());
        }

        public ActionResult ActiveTaskList()
        {
            var taskListEntities = _taskRepository.List();
            return View(taskListEntities);
        }

        public ActionResult Delete(int id)
        {
            var task = _taskRepository.GetById(id);
            _taskRepository.Remove(id);
            return RedirectToAction("ActiveTaskList");
        }

    }
}