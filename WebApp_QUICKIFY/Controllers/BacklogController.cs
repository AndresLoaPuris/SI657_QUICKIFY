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

        public ActionResult Index()
        {
            return View(backlogService.getUserStoriesByProjectName(ProyectController.Static_Name));
        }

      
        public ActionResult Create()
        {
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


            ViewBag.User_Id = new SelectList(backlogService.getTeamUsersByProjectName(ProyectController.Static_Name), "Id", "Name");

            return View(userStories);
        }

       
        public ActionResult Edit(int? id)
        {

            UserStories userStories = backlogService.getUserStoryById(id);
            Static_StateKanban = userStories.StateKanban;
            ViewBag.User_Id = new SelectList(backlogService.getTeamUsersByProjectName(ProyectController.Static_Name), "Id", "Name");
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

            ViewBag.User_Id = new SelectList(backlogService.getTeamUsersByProjectName(ProyectController.Static_Name), "Id", "Name");
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
