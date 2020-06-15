using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SI657_QUICKIFY.Controllers
{
    public class BacklogController : Controller
    {
        // GET: Backlog
        public ActionResult Index()
        {
            return View();
        }
    }
}