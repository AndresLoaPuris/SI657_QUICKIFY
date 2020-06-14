using QUICKIFYRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SI657_QUICKIFY.Controllers
{
    public class ProyectController : Controller
    {
        public static string Static_Name { get; set; }

        public ActionResult Index() {

            return View(SI657_Entities.getInstance().Equipo.ToList());
        }

        public ActionResult Temporal(string name)
        {
            Static_Name = name;
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Lider_Id = new SelectList(SI657_Entities.getInstance().Usuario.Where(s => s.Cargo_Id == 2), "Nombre", "Nombre");
            ViewBag.Usuario_Id = new SelectList(SI657_Entities.getInstance().Usuario.Where(s => s.Cargo_Id == 1), "Nombre", "Nombre");
            return View();
        }

        public ActionResult SaveEquipo(string nombre, string lider, Usuario[] usuarios) {

            string result = "Error! Proyect Is Not Complete!";
            if (nombre != null && usuarios != null) {

                Proyecto proyecto = new Proyecto();
                proyecto.Nombre = nombre;
                proyecto.isDelete = 0;
                SI657_Entities.getInstance().Proyecto.Add(proyecto);
                SI657_Entities.getInstance().SaveChanges();
                int Last_Proyect = SI657_Entities.getInstance().Proyecto.Max(p => p.Id);

                Equipo tempequipo = new Equipo();
                tempequipo.Proyecto_Id = Last_Proyect;
                Usuario tempLider = SI657_Entities.getInstance().Usuario.Where(s => s.Nombre == lider).FirstOrDefault<Usuario>();
                tempequipo.Usuario_Id = tempLider.Id;
                tempequipo.isAdmin = 1;
                SI657_Entities.getInstance().Equipo.Add(tempequipo);
                //SI657_Entities.getInstance().SaveChanges();

                foreach (var item in usuarios) {

                    Equipo equipo = new Equipo();
                    equipo.Proyecto_Id = Last_Proyect;
                    Usuario temp = SI657_Entities.getInstance().Usuario.Where(s => s.Nombre == item.Nombre).FirstOrDefault<Usuario>();
                    equipo.Usuario_Id = temp.Id;
                    equipo.isAdmin = 0;
                    SI657_Entities.getInstance().Equipo.Add(equipo);
                    SI657_Entities.getInstance().SaveChanges();
                }

                SI657_Entities.getInstance().SaveChanges();
                result = "Success! Proyect Is Complete!";
            }
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}