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
using QUICKIFYService.Auth;

namespace WebApp_QUICKIFY.Controllers
{
    public class AuthController : Controller
    {
        private AuthService authService = new AuthService();
        public static string Static_Email { get; set; }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(AuthUser authUser)
        {
            if (authService.getAccess(authUser))
            {
                
                FormsAuthentication.SetAuthCookie(authService.getNameUser(authUser), false);
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
            if (!authService.getUserExists(users)) {
                if (ModelState.IsValid)
                {
                    authService.signUp(users);
                    return RedirectToAction("Login");
                }
            }

            ModelState.AddModelError("", "Usuario y/o Email Existente");
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
                authService.getDispose();
            }
            base.Dispose(disposing);
        }
    }
}
