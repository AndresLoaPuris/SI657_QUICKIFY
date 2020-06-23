using QUICKIFYRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SI657_QUICKIFY.Controllers
{
    [Authorize]
    public class BoardController : Controller
    {
        private SI657_Entities db = new SI657_Entities();
        // GET: Board
        public ActionResult Kanban()
        {
            var list = db.HistoriaUsuario.ToList().Where(s => s.isDelete == 0 && s.Proyecto.Nombre == ProyectController.Static_Name);
            return View(list);
        }
    }
}