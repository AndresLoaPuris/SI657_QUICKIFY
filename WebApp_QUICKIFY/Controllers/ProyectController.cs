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
    public class ProyectController : Controller
    {
        private SI657_Entities db = new SI657_Entities();
        public static string Static_Name { get; set; }
        // GET: Proyect
        public ActionResult Index()
        {
            int id = db.Users.Where(s => s.Email == AuthController.Static_Email).FirstOrDefault<Users>().Id;
            return View(db.Database.SqlQuery<Proyects>("SELECT p.Id , p.Name , p.isDelete FROM Team e JOIN Proyects p ON e.Proyect_Id = p.Id WHERE p.isDelete = 0 and e.User_Id = @Id ", new SqlParameter("Id", id)).ToList());
        }

        public ActionResult PassKanban(string name)
        {
            Static_Name = name;
            return RedirectToAction("Kanban", "Board");
        }

        // GET: Proyect/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyects proyects = db.Proyects.Find(id);
            if (proyects == null)
            {
                return HttpNotFound();
            }
            return View(proyects);
        }

        // GET: Proyect/Create
        public ActionResult Create()
        {
            ViewBag.Usuario_Id = new SelectList(db.Users, "Name", "Name");
            ViewBag.Role_Id = new SelectList(db.Role, "Name", "Name");
            return View();
        }

        // POST: Proyect/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,isDelete")] Proyects proyects)
        {
            if (ModelState.IsValid)
            {
                db.Proyects.Add(proyects);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Role_Id = new SelectList(db.Role, "Name", "Name");
            return View(proyects);
        }

        // GET: Proyect/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyects proyects = db.Proyects.Find(id);
            if (proyects == null)
            {
                return HttpNotFound();
            }
            return View(proyects);
        }

        public ActionResult SaveEquipo(string nameProyect, Users[] users)
        {

            string result = "Error! Proyect Is Not Complete!";
            Proyects proyect = new Proyects();
            proyect.Name = nameProyect;
            proyect.isDelete = 0;
            db.Proyects.Add(proyect);
            db.SaveChanges();

            int lastProyect = db.Proyects.Max(p => p.Id);

            foreach (var item in users)
            {

                Team equipo = new Team();
                equipo.Proyect_Id = lastProyect;
                Role roleTemp = db.Role.Where(s => s.Name == item.Name).FirstOrDefault<Role>();
                equipo.User_Id = db.Users.Where(s => s.Name == item.Name).FirstOrDefault<Users>().Id;
                equipo.Role_Id = db.Role.Where(s => s.Name == item.Password).FirstOrDefault<Role>().Id;
                db.Team.Add(equipo);
               db.SaveChanges();
            }

           db.SaveChanges();


            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // POST: Proyect/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,isDelete")] Proyects proyects)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyects).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proyects);
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
