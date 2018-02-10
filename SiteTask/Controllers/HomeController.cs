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

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Worker> workers = db.Workers;
            IEnumerable<Task> tasks = db.Tasks;
            IEnumerable<Time> times = db.Times;
            ViewBag.Workers = workers;
            ViewBag.Tasks = tasks;
            ViewBag.Times = times;
            return View();
        }
        public ActionResult RemoveWorker(int id)
        {
            Worker b = db.Workers.Find(id);
                db.Workers.Remove(b);
                db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult addWorker()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addWorker(Worker worker)
        {
            db.Entry(worker).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditWorker(int? Id)
        {
            Worker worker = db.Workers.Find(Id);
            return View(worker);
        }

        [HttpPost]
        public ActionResult EditWorker(Worker worker)
        {
            db.Entry(worker).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}