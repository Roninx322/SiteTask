using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SiteTask.Models;
using System.Collections;



namespace SiteTask.Controllers
{
    public class SortTask
    {
        JobContext db;
        public SortTask(JobContext db1)
        {
            this.db = db1;
        }

        public List<SortLIst> listSort()
        {
            List<Time> timeList = new List<Time>();
            List<Task> taskList = new List<Task>();
            taskList = this.db.Tasks.ToList();
            timeList = this.db.Times.ToList();
            List<SortLIst> listqwe = timeList.GroupBy(q => new { q.TaskId, q.WorkerId }, p => p.Hours)
                    .Select(g => new SortLIst
                    {
                        TaskId = g.Key.TaskId,
                        WorkerId = g.Key.WorkerId,
                        Hours = g.Sum(p=>p)
                    }).ToList();
            listqwe = listqwe.GroupBy(q=> q.TaskId,p=> new { p.WorkerId,p.Hours})
                .Select(g=> new SortLIst
                {
                    TaskId= g.Key,
                    WorkerId= g.ElementAt(1),
                })
            //for (int i = 0; i < taskList.Count; i++)
            //{
            //    int max;
            //    for (int j = 0; j < listqwe.Count; j++)
            //    {
            //        if (taskList[i].TaskId == listqwe[j].Task)
            //        {
                        
            //        }
            //    }
               
            //}
            return listqwe;
        }
    }

    public class HomeController : Controller
    {
        
        JobContext db = new JobContext();

        [HttpGet]
        public ActionResult Index()
        {
            SortTask sortTask = new SortTask(db);
            IEnumerable<Worker> workers = db.Workers;
            IEnumerable<Task> tasks = db.Tasks;
            IEnumerable<Time> times = db.Times;
            //IEnumerable<SortLIst> sortLIst = sortTask.listSort().ToArray().ToList();
            //var grupTask = db.Times.GroupBy(q => new { q.TaskId, q.WorkerId }, p => new { p.Hours, p.Date })
            //    .Select(g => new
            //    {

            //        TaskID = g.Key.TaskId,
            //        WorkerID = g.Key.WorkerId,
            //        Hours = g.Sum(p => p.Hours),
            //    });
            //var gr = grupTask.GroupBy(q => q.TaskID, p => new { p.Hours, p.WorkerID }).Select
            //    (g => new
            //    {
            //        taskId = g.Key,
            //        hours = g.Max(),

            //    });
            ViewBag.Workers = workers;
            ViewBag.Tasks = tasks;
            ViewBag.Times = times;
            //ViewBag.SortTask = sortLIst;
            return View();
        }

        //конечно такой деревянный способ, еще не искал как можно это более динамически записать, но для добавления для каждой таблицы делать отдельную форму такое себе удовольствие 

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

        //Edit, Add, Remove for Time
        public ActionResult RemoveTime(int id)
        {
            Time b = db.Times.Find(id);
            db.Times.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult addTime()
        {
            ViewBag.Tasks = db.Tasks;
            ViewBag.Workers = db.Workers;
            return View();
        }

        [HttpPost]
        public ActionResult addTime(Time time)
        {
            time.Group = Convert.ToInt32(time.TaskId.ToString() + time.WorkerId.ToString());
            db.Entry(time).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditTime(int? Id)
        {
            ViewBag.Tasks = db.Tasks;
            ViewBag.Workers = db.Workers;
            Time time = db.Times.Find(Id);
            return View(time);
        }

        [HttpPost]
        public ActionResult EditTime(Time time)
        {
            db.Entry(time).State = EntityState.Modified;
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