using System.Linq;
using System.Web.Mvc;
using QUICKIFYRepository;
using QUICKIFYService.Proyect;

namespace WebApp_QUICKIFY.Controllers
{
    [Authorize]
    public class ProyectController : Controller
    {

        private ProyectService proyectService = new ProyectService();
        public static string Static_Name { get; set; }
        
        public ActionResult Index()
        {
            return View(proyectService.getProjectsByEmailFromTheUser(AuthController.Static_Email));
        }

        public ActionResult PassKanban(string name)
        {
            Static_Name = name;
            return RedirectToAction("Kanban", "Board");
        }


        public ActionResult Create()
        {
            ViewBag.Usuario_Id = new SelectList(proyectService.getUsers(AuthController.Static_Email), "Name", "Name");
            ViewBag.Role_Id = new SelectList(proyectService.getRole(), "Name", "Name");
            return View();
        }

        public ActionResult SaveEquipo(string nameProyect, Users[] users)
        {
            string result = "Error! Proyect Is Not Complete!";
            Users temp = new Users();
            temp.Name = proyectService.getNameUSer(AuthController.Static_Email);
            temp.Password = "Administrador";
            
            users = users.Concat(new Users[] { temp } ).ToArray();

            proyectService.addProyect(nameProyect, users);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                proyectService.getDispose();
            }
            base.Dispose(disposing);
        }
    }
}
