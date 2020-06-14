using QUICKIFYRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SI657_QUICKIFY.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		
		public ActionResult Index()
		{
			
			return View();
		}

	}
}