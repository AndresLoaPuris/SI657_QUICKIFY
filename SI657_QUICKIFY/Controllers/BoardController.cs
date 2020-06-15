using QUICKIFYRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SI657_QUICKIFY.Controllers
{
    public class BoardController : Controller
    {
        // GET: Board
        public ActionResult Kanban()
        {
            return View(SI657_Entities.getInstance().HistoriaUsuario.ToList());
        }
    }
}