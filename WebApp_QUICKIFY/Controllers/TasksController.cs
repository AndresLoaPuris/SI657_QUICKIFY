using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QUICKIFYRepository;

namespace WebApp_QUICKIFY.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private SI657_Entities db = new SI657_Entities();
        public static int Static_HU { get; set; }
        public static int Static_isDelete { get; set; }
        public static int Static_isCompleted { get; set; }

        // GET: Tasks
        public ActionResult Index()
        {
            return View(db.UserStories.Where(s => s.isDelete == 0 && s.Proyects.Name == ProyectController.Static_Name).ToList());
        }


        public ActionResult Tasks(int id)
        {
            Static_HU = id;
            ViewBag.NameHU = db.UserStories.Find(id).Title;
            return View(db.Tasks.Where(s => s.isDelete == 0 && s.UserStories.Proyects.Name == ProyectController.Static_Name && s.UserStory_Id == Static_HU).ToList());
        }

        public ActionResult FinalizarTask(int? id, int? UserStory_id) {

            Tasks tasks = db.Tasks.Find(id);
            tasks.isCompleted = 1;
            db.Entry(tasks).State = EntityState.Modified;
            db.SaveChanges();

            UserStories userStories = db.UserStories.Find(UserStory_id);

            int userStoriesFinish = 0;

            foreach (var item in userStories.Tasks.Where(s => s.isDelete == 0)) {
                if (item.isCompleted == 1) {
                    userStoriesFinish += 1;
                }
            }

            if (userStoriesFinish == 0)
            {
                userStories.StateKanban = "POR HACER";
                
            }
            else if (userStoriesFinish > 0 && userStoriesFinish < userStories.Tasks.Where(s => s.isDelete == 0).Count())
            {
                userStories.StateKanban = "EN CURSO";
            }
            else if(userStoriesFinish == userStories.Tasks.Where(s => s.isDelete == 0).Count())
            {
                userStories.StateKanban = "TERMINADO";
            }

            db.Entry(userStories).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult RestaurarTask(int? id, int? UserStory_id)
        {

            Tasks tasks = db.Tasks.Find(id);
            tasks.isCompleted = 0;
            db.Entry(tasks).State = EntityState.Modified;
            db.SaveChanges();
            UserStories userStories = db.UserStories.Find(UserStory_id);

            int userStoriesFinish = 0;

            foreach (var item in userStories.Tasks.Where(s => s.isDelete == 0))
            {
                if (item.isCompleted == 1)
                {
                    userStoriesFinish += 1;
                }
            }

            if (userStoriesFinish == 0)
            {
                userStories.StateKanban = "POR HACER";

            }
            else if (userStoriesFinish > 0 && userStoriesFinish < userStories.Tasks.Where(s => s.isDelete == 0).Count())
            {
                userStories.StateKanban = "EN CURSO";
            }
            else if (userStoriesFinish == userStories.Tasks.Where(s => s.isDelete == 0).Count())
            {
                userStories.StateKanban = "TERMINADO";
            }

            db.Entry(userStories).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tasks tasks)
        {
            tasks.UserStory_Id = Static_HU;
            tasks.isDelete = 0;
            tasks.isCompleted = 0;

            if (ModelState.IsValid)
            {
                db.Tasks.Add(tasks);
                db.SaveChanges();
                return RedirectToAction("Tasks", new { id = Static_HU });
            }

            return View(tasks);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            Tasks tasks = db.Tasks.Find(id);
            Static_isCompleted = tasks.isCompleted;
            Static_isDelete = tasks.isDelete;
            return View(tasks);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tasks tasks)
        {
            tasks.UserStory_Id = Static_HU;
            tasks.isDelete = Static_isDelete;
            tasks.isCompleted = Static_isCompleted;

            if (ModelState.IsValid)
            {
                db.Entry(tasks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Tasks", new { id = Static_HU });
            }
            
            return View(tasks);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            Tasks tasks = db.Tasks.Find(id);
            tasks.isDelete = 1;
            db.Entry(tasks).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Tasks", new { id = Static_HU });
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
