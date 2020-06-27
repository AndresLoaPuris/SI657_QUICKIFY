using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QUICKIFYRepository;

namespace WebApp_QUICKIFY.Controllers
{
    [Authorize]
    public class BacklogController : Controller
    {
        private SI657_Entities db = new SI657_Entities();
        private DefStateKanban defState = new DefStateKanban();
        private static string Static_StateKanban { get; set; }

        public ActionResult Index()
        {
            var userStories =  db.UserStories.Include(u => u.Proyects).Include(u => u.Users).Where(s => s.isDelete == 0 && s.Proyects.Name == ProyectController.Static_Name).ToList();
            return View(userStories.ToList());
        }

      
        public ActionResult Create()
        {
            
            
            int id = db.Proyects.Where(s => s.Name == ProyectController.Static_Name).FirstOrDefault<Proyects>().Id;
            ViewBag.User_Id = new SelectList(db.Database.SqlQuery<Users>("SELECT u.Id , u.Name , u.Email , u.Password FROM [dbo].[Users] u JOIN [dbo].[Team] t ON u.Id = t.User_Id WHERE t.Proyect_Id = @Id ", new SqlParameter("Id", id)).ToList(), "Id", "Name");
            return View();
        }

       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,Priority,StateKanban,isDelete,Sprint,Proyect_Id,User_Id")] UserStories userStories)
        {
            userStories.StateKanban = "POR HACER";
            userStories.isDelete = 0;
            userStories.Proyect_Id = db.Proyects.Where(s => s.Name == ProyectController.Static_Name).FirstOrDefault().Id;

            if (ModelState.IsValid)
            {
                db.UserStories.Add(userStories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           
            int id = db.Proyects.Where(s => s.Name == ProyectController.Static_Name).FirstOrDefault<Proyects>().Id;
            ViewBag.User_Id = new SelectList(db.Database.SqlQuery<Users>("SELECT u.Id , u.Name , u.Email , u.Password FROM [dbo].[Users] u JOIN [dbo].[Team] t ON u.Id = t.User_Id WHERE t.Proyect_Id = @Id ", new SqlParameter("Id", id)).ToList(), "Id", "Name");
            
            return View(userStories);
        }

       
        public ActionResult Edit(int? id)
        {

            UserStories userStories = db.UserStories.Find(id);
            Static_StateKanban = userStories.StateKanban;
            int idP = db.Proyects.Where(s => s.Name == ProyectController.Static_Name).FirstOrDefault<Proyects>().Id;
            ViewBag.User_Id = new SelectList(db.Database.SqlQuery<Users>("SELECT u.Id , u.Name , u.Email , u.Password FROM [dbo].[Users] u JOIN [dbo].[Team] t ON u.Id = t.User_Id WHERE t.Proyect_Id = @Id ", new SqlParameter("Id", id)).ToList(), "Id", "Name");
            ViewBag.StateKanban = new SelectList(defState.Name, userStories.StateKanban);
            return View(userStories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserStories userStories)
        {
            userStories.Proyect_Id = db.Proyects.Where(s => s.Name == ProyectController.Static_Name).FirstOrDefault().Id;
            userStories.isDelete = 0;
            userStories.StateKanban = Static_StateKanban;
            if (ModelState.IsValid)
            {
                db.Entry(userStories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          
            int id = db.Proyects.Where(s => s.Name == ProyectController.Static_Name).FirstOrDefault<Proyects>().Id;
            ViewBag.User_Id = new SelectList(db.Database.SqlQuery<Users>("SELECT u.Id , u.Name , u.Email , u.Password FROM [dbo].[Users] u JOIN [dbo].[Team] t ON u.Id = t.User_Id WHERE t.Proyect_Id = @Id ", new SqlParameter("Id", id)).ToList(), "Id", "Name");
            ViewBag.StateKanban = new SelectList(defState.Name, userStories.StateKanban);
            return View(userStories);
        }


        public ActionResult Delete(int? id)
        {
            UserStories userStories = db.UserStories.Find(id);
            userStories.isDelete = 1;
            db.Entry(userStories).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
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
