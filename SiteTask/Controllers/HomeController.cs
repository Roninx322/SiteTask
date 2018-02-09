using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SiteTask.Models;

namespace SiteTask.Controllers
{
    public class HomeController : Controller
    {

        JobContext db = new JobContext();
        public ActionResult Index()
        {
            IEnumerable<Worker> workers = db.Workers;
            IEnumerable<Task> tasks = db.Tasks;
            ViewBag.Workers = workers;
            ViewBag.Tasks = tasks;

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}