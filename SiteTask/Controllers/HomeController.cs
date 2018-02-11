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
        //конечно такой деревянный способ еще не искал как можно это более динамически записать но для добавления для каждой таблицы делать отдельную форму такое себе удовольствие 

        //Edit, Add, Remove for Worker
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
        
        //Edit, Add, Remove for Task
        public ActionResult RemoveTask(int id)
        {
            Task b = db.Tasks.Find(id);
            db.Tasks.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult addTask()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addTask(Task task)
        {
            db.Entry(task).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditTask(int? Id)
        {
            Task task = db.Tasks.Find(Id);
            return View(task);
        }

        [HttpPost]
        public ActionResult EditTask(Task task)
        {
            db.Entry(task).State = EntityState.Modified;
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