using QUICKIFYRepository;
using QUICKIFYService.Proyect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SI657_QUICKIFY.Controllers
{
    [Authorize]
    public class ProyectController : Controller
    {
        private ProyectService proyectService = new ProyectService();
        public static string Static_Name { get; set; }

        public ActionResult Index()
        {
            return View(proyectService.getProyects(AuthController.Static_Email));
        }

        public ActionResult PassKanban(string name)
        {
            Static_Name = name;
            return RedirectToAction("Kanban", "Board");
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

                proyectService.addProyect(nombre);
                proyectService.addTeam(proyectService.lastProyect(), lider, usuarios);

                result = "Success! Proyect Is Complete!";
            }
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}