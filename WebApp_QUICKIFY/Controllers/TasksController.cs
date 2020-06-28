using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QUICKIFYRepository;
using QUICKIFYService.Task;

namespace WebApp_QUICKIFY.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {

        TasksService tasksService= new TasksService();

        public static int Static_HU { get; set; }
        public static int Static_isDelete { get; set; }
        public static int Static_isCompleted { get; set; }

        
        public ActionResult Index()
        {
            return View(tasksService.getTasksByNameProyect(ProyectController.Static_Name, AuthController.Static_Email));
        }


        public ActionResult Tasks(int id)
        {
            Static_HU = id;
            ViewBag.NameHU = tasksService.getTitleUserStoryById(id);
            return View(tasksService.getTasksByNameProyectAndIdUserStory(ProyectController.Static_Name, id));
        }

        public ActionResult FinalizarTask(int? id, int? UserStory_id)
        {
            tasksService.finishTask(id, UserStory_id);
            return RedirectToAction("Index");
        }


        public ActionResult RestaurarTask(int? id, int? UserStory_id)
        {
            tasksService.restoreTask(id, UserStory_id);
            return RedirectToAction("Index");
        }

        private bool CheckDateRange(DateTime date)
        {
            DateTime dateNow = DateTime.Now.AddDays(-1);
            DateTime dateFuture = DateTime.Now.AddYears(3);


            if (dateNow <= date && date <= dateFuture)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

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

            if (ModelState.IsValid && CheckDateRange(tasks.IntendedDate))
            {
                tasksService.addTask(tasks);
                return RedirectToAction("Tasks", new { id = Static_HU });
            }

            return View(tasks);
        }

        
        public ActionResult Edit(int? id)
        {
            Tasks tasks = tasksService.getUserStoryById(id);
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

            if (ModelState.IsValid && CheckDateRange(tasks.IntendedDate))
            {
                tasksService.editTask(tasks);
                return RedirectToAction("Tasks", new { id = Static_HU });
            }
            
            return View(tasks);
        }

        
        public ActionResult Delete(int? id)
        {
            tasksService.deleteTask(id);
            return RedirectToAction("Tasks", new { id = Static_HU });
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                tasksService.getDispose();
            }
            base.Dispose(disposing);
        }
    }
}
