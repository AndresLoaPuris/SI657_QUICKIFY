using QUICKIFYRepository;
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
        private SI657_Entities db = new SI657_Entities();
        public ActionResult Kanban()
        {
            var userStories = db.UserStories.ToList().Where(s => s.isDelete == 0 && s.Proyects.Name == ProyectController.Static_Name);
            

            foreach (var item in userStories) {

                int userStoriesFinish = 0;

                foreach (var task in item.Tasks.Where( x => x.isDelete == 0))
                {
                    if (task.isCompleted == 1)
                    {
                        userStoriesFinish += 1;
                    }
                }

                if (userStoriesFinish == 0)
                {
                    item.StateKanban = "POR HACER";

                }
                else if (userStoriesFinish > 0 && userStoriesFinish < item.Tasks.Where(x => x.isDelete == 0).Count())
                {
                    item.StateKanban = "EN CURSO";
                }
                else if (userStoriesFinish == item.Tasks.Where(x => x.isDelete == 0).Count())
                {
                    item.StateKanban = "TERMINADO";
                }

                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }



            return View(userStories);
        }
    }
}