using QUICKIFYRepository;
using QUICKIFYService.Board;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static WebApp_QUICKIFY.Controllers.BacklogController;

namespace WebApp_QUICKIFY.Controllers
{
    [Authorize]
    public class BoardController : Controller
    {

        private BoardService boardService = new BoardService();

        public ActionResult Kanban()
        {
            IEnumerable<Sprint> IESprint = new List<Sprint>() {
                new Sprint { Id=1, Name="Sprint N° 1"},
                new Sprint { Id=2, Name="Sprint N° 2"},
                new Sprint { Id=3, Name="Sprint N° 3"},
                new Sprint { Id=4, Name="Sprint N° 4"},
                new Sprint { Id=5, Name="Sprint N° 5"},
                new Sprint { Id=6, Name="Sprint N° 6"},
                new Sprint { Id=7, Name="Sprint N° 7"},
                new Sprint { Id=8, Name="Sprint N° 8"},
                new Sprint { Id=9, Name="Sprint N° 9"},
                new Sprint { Id=10, Name="Sprint N° 10"}
            }.AsEnumerable();

            ViewBag.Sprint = new SelectList(IESprint, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Kanban(int? Sprint)
        {
            return RedirectToAction("KanbanByIdSprint", new { id = Sprint });
        }


        public ActionResult KanbanByIdSprint(int id)
        {
            IEnumerable<Sprint> IESprint = new List<Sprint>() {
                new Sprint { Id=1, Name="Sprint N° 1"},
                new Sprint { Id=2, Name="Sprint N° 2"},
                new Sprint { Id=3, Name="Sprint N° 3"},
                new Sprint { Id=4, Name="Sprint N° 4"},
                new Sprint { Id=5, Name="Sprint N° 5"},
                new Sprint { Id=6, Name="Sprint N° 6"},
                new Sprint { Id=7, Name="Sprint N° 7"},
                new Sprint { Id=8, Name="Sprint N° 8"},
                new Sprint { Id=9, Name="Sprint N° 9"},
                new Sprint { Id=10, Name="Sprint N° 10"}
            }.AsEnumerable();

            ViewBag.Sprint = new SelectList(IESprint, "Id", "Name",id);
            ViewBag.NumbSprint = id;
            return View(boardService.getUserStoriesByNameProyect(ProyectController.Static_Name).Where(s => s.Sprint == id));
        }

        [HttpPost]
        public ActionResult KanbanByIdSprint(int? Sprint)
        {
            IEnumerable<Sprint> IESprint = new List<Sprint>() {
                new Sprint { Id=1, Name="Sprint N° 1"},
                new Sprint { Id=2, Name="Sprint N° 2"},
                new Sprint { Id=3, Name="Sprint N° 3"},
                new Sprint { Id=4, Name="Sprint N° 4"},
                new Sprint { Id=5, Name="Sprint N° 5"},
                new Sprint { Id=6, Name="Sprint N° 6"},
                new Sprint { Id=7, Name="Sprint N° 7"},
                new Sprint { Id=8, Name="Sprint N° 8"},
                new Sprint { Id=9, Name="Sprint N° 9"},
                new Sprint { Id=10, Name="Sprint N° 10"}
            }.AsEnumerable();

            ViewBag.Sprint = new SelectList(IESprint, "Id", "Name", Sprint);
            ViewBag.NumbSprint = Sprint;
            return View(boardService.getUserStoriesByNameProyect(ProyectController.Static_Name).Where(s => s.Sprint == Sprint));
        }

    }
}