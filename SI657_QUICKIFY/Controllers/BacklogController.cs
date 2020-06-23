using QUICKIFYRepository;
using QUICKIFYService.Backlog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SI657_QUICKIFY.Controllers
{
    [Authorize]
    public class BacklogController : Controller
    {

        
        public static int Static_HU { get; set; }

        private BacklogService backlogService = new BacklogService();


        public ActionResult Index()
        {
            return View(backlogService.getUserStories(ProyectController.Static_Name));
        }


        public ActionResult Delete(int? id)
        {
            backlogService.deleteUserStory(id);
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? id)
        {
            HistoriaUsuario historiaUsuario = backlogService.getUserStoryById(id);
            return View(historiaUsuario);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HistoriaUsuario historiaUsuario)
        {
            historiaUsuario.Proyecto_Id = backlogService.getIdProyectByName(ProyectController.Static_Name);

            if (ModelState.IsValid)
            {
                backlogService.editUserStory(historiaUsuario);
                return RedirectToAction("Index");
            }

            return View(historiaUsuario);
        }


        public ActionResult Create()
        {
            return View();
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HistoriaUsuario historiaUsuario)
        {
            historiaUsuario.Proyecto_Id = backlogService.getIdProyectByName(ProyectController.Static_Name);
            historiaUsuario.isDelete = 0;

            if (ModelState.IsValid && CheckDateRange(historiaUsuario.FechaEstimada))
            {
                backlogService.addUserStory(historiaUsuario);
                return RedirectToAction("Index");
            }

            return View(historiaUsuario);
        }


        public ActionResult Index_Task(int id)
        {
            Static_HU = id;
            ViewBag.NameHU = backlogService.getUserStoryTitle(id);
            return View(backlogService.getTasksByIdOfAUserStory(id));
        }


        public ActionResult Delete_Task(int? id)
        {
            backlogService.deleteTask(id);
            return RedirectToAction("Index_Task", new { id = Static_HU });
        }


        public ActionResult Edit_Task(int? id)
        {
            return View(backlogService.getTaskById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Task(Tarea tarea)
        {
            tarea.HistoriaUsuario_Id = Static_HU;

            if (ModelState.IsValid)
            {
                backlogService.editTask(tarea);
                return RedirectToAction("Index_Task", new { id = Static_HU });
            }

            return View(tarea);
        }


        public ActionResult Create_Task()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Task(Tarea tarea)
        {
            tarea.HistoriaUsuario_Id = Static_HU;
            tarea.isDelete = 0;

            if (ModelState.IsValid)
            {
                backlogService.addTask(tarea);
                return RedirectToAction("Index_Task",new { id = Static_HU });
            }

            return View(tarea);
        }


        protected override void Dispose(bool disposing)
        {
            var db = new SI657_Entities();

            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}