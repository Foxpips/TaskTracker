using System.Data.Entity;
using System.Web.Mvc;
using TaskTracker.Helpers;
using TaskTracker.Infrastructure.Entities;
using TaskTracker.Infrastructure.Repositories;
using TaskTracker.Logging;

namespace TaskTracker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return RedirectToAction("Index","TaskList");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}