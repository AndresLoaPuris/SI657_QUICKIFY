using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using QUICKIFYRepository;

namespace WebApp_QUICKIFY.Controllers
{
    public class AuthController : Controller
    {
        private SI657_Entities db = new SI657_Entities();
        public static string Static_Email { get; set; }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(AuthUser authUser)
        {
            if (db.Users.Any(x => x.Email == authUser.Email && x.Password == authUser.Password))
            {
                Users users = db.Users.Where(s => s.Email == authUser.Email).FirstOrDefault<Users>();
                FormsAuthentication.SetAuthCookie(users.Name, false);
                Static_Email = authUser.Email;
                return RedirectToAction("Index", "Proyect");
            }

            ModelState.AddModelError("", "Email y/o Password Invalido");
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Users users)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(users);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
