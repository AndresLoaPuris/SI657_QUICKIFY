using QUICKIFYRepository;
using QUICKIFYService.Board;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp_QUICKIFY.Controllers
{
    [Authorize]
    public class BoardController : Controller
    {

        private BoardService boardService = new BoardService();

        public ActionResult Kanban()
        {
            return View(boardService.getUserStoriesByNameProyect(ProyectController.Static_Name));
        }
    }
}