using QUICKIFYRepository;
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
        private SI657_Entities db = new SI657_Entities();

        public ActionResult Index()
        {
            return View(db.HistoriaUsuario.ToList().Where( s => s.isDelete == 0 && s.Proyecto.Nombre == ProyectController.Static_Name));
        }

        public ActionResult Index_Task(int id)
        {
            Static_HU = id;
            ViewBag.NameHU = db.HistoriaUsuario.Find(id).Titulo;
            return View(db.Tarea.ToList().Where(s => s.isDelete == 0 && s.HistoriaUsuario_Id == id));
        }

        public ActionResult Delete(int? id)
        {
            HistoriaUsuario historiaUsuario = db.HistoriaUsuario.Find(id);
            historiaUsuario.isDelete = 1;
            db.Entry(historiaUsuario).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete_Task(int? id)
        {
            Tarea tarea = db.Tarea.Find(id);
            tarea.isDelete = 1;
            db.Entry(tarea).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index_Task", new { id = Static_HU });
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoriaUsuario historiaUsuario = db.HistoriaUsuario.Find(id);
            if (historiaUsuario == null)
            {
                return HttpNotFound();
            }
            
            return View(historiaUsuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Descripcion,FechaEstimada,Prioridad,Sprint,EstadoKanban,isDelete,Proyecto_Id")] HistoriaUsuario historiaUsuario)
        {
            Proyecto proyecto = db.Proyecto.Where(s => s.Nombre == ProyectController.Static_Name).FirstOrDefault();
            historiaUsuario.Proyecto_Id = proyecto.Id;

            if (ModelState.IsValid)
            {
                db.Entry(historiaUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(historiaUsuario);
        }


        public ActionResult Edit_Task(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tarea.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }

            return View(tarea);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Task(Tarea tarea)
        {
            tarea.HistoriaUsuario_Id = Static_HU;

            if (ModelState.IsValid)
            {
                db.Entry(tarea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index_Task", new { id = Static_HU });
            }

            return View(tarea);
        }


        // GET: Backlog
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Descripcion,FechaEstimada,Prioridad,Sprint,EstadoKanban,isDelete,Proyecto_Id")] HistoriaUsuario historiaUsuario)
        {
            Proyecto proyecto = db.Proyecto.Where(s => s.Nombre == ProyectController.Static_Name).FirstOrDefault();
            historiaUsuario.Proyecto_Id = proyecto.Id;
            historiaUsuario.isDelete = 0;

            if (ModelState.IsValid)
            {
                db.HistoriaUsuario.Add(historiaUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(historiaUsuario);
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
                db.Tarea.Add(tarea);
                db.SaveChanges();
                return RedirectToAction("Index_Task",new { id = Static_HU });
            }


            return View(tarea);
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