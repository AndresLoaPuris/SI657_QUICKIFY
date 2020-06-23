using QUICKIFYRepository;
using QUICKIFYService.Board;
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

        private BoardService boardService = new BoardService();

        public ActionResult Kanban()
        {
            return View(boardService.getUserStories(ProyectController.Static_Name));
        }
    }
}