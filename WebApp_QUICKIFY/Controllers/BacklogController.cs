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
using QUICKIFYService.Backlog;

namespace WebApp_QUICKIFY.Controllers
{
    [Authorize]
    public class BacklogController : Controller
    {
        
        BacklogService backlogService = new BacklogService();

        private static string Static_StateKanban { get; set; }

        public class Sprint {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public ActionResult Index()
        {
            return View(backlogService.getUserStoriesByProjectName(ProyectController.Static_Name));
        }

      
        public ActionResult Create()
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
            ViewBag.User_Id = new SelectList(backlogService.getTeamUsersByProjectName(ProyectController.Static_Name), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserStories userStories)
        {
            userStories.StateKanban = "POR HACER";
            userStories.isDelete = 0;
            userStories.Proyect_Id = backlogService.getIdByProjectName(ProyectController.Static_Name);

            if (ModelState.IsValid)
            {
                backlogService.addUserStory(userStories);
                return RedirectToAction("Index");
            }

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
            ViewBag.User_Id = new SelectList(backlogService.getTeamUsersByProjectName(ProyectController.Static_Name), "Id", "Name");

            return View(userStories);
        }

       
        public ActionResult Edit(int? id)
        {

            UserStories userStories = backlogService.getUserStoryById(id);
            Static_StateKanban = userStories.StateKanban;
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

            ViewBag.Sprint = new SelectList(IESprint, "Id", "Name", userStories.Sprint);
            ViewBag.User_Id = new SelectList(backlogService.getTeamUsersByProjectName(ProyectController.Static_Name), "Id", "Name", userStories.User_Id);
            return View(userStories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserStories userStories)
        {
            userStories.Proyect_Id = backlogService.getIdByProjectName(ProyectController.Static_Name);
            userStories.isDelete = 0;
            userStories.StateKanban = Static_StateKanban;

            if (ModelState.IsValid)
            {
                backlogService.editUserStory(userStories);
                return RedirectToAction("Index");
            }

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

            ViewBag.Sprint = new SelectList(IESprint, "Id", "Name", userStories.Sprint);
            ViewBag.User_Id = new SelectList(backlogService.getTeamUsersByProjectName(ProyectController.Static_Name), "Id", "Name", userStories.User_Id);
            return View(userStories);
        }


        public ActionResult Delete(int? id)
        {
            backlogService.deleteUserStoryById(id);
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                backlogService.getDispose();
            }
            base.Dispose(disposing);
        }
    }
}
