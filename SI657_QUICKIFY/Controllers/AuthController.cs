using QUICKIFYRepository;
using QUICKIFYService.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SI657_QUICKIFY.Controllers
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
        public ActionResult Login(AuthUsuario authUsuario)
        {


            if (authService.getAccess(authUsuario.Email, authUsuario.Password)) {

                Usuario usuario = authService.getUser(authUsuario.Email);
                FormsAuthentication.SetAuthCookie(usuario.Nombre, false);
                Static_Email = authUsuario.Email;
                return RedirectToAction("Index", "Proyect");
            }

            ModelState.AddModelError("", "Email y/o Password Invalido");
            return View();
            
        }


        public ActionResult SignUp()
        {
            ViewBag.Cargo_Id = new SelectList(SI657_Entities.getInstance().Cargo, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                authService.addUser(usuario);
                return RedirectToAction("Login");
            }

            return View(usuario);
        }


        public ActionResult ProfileUser()
        {
            Usuario usuario = authService.getUser(Static_Email);
            return View(usuario);
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }


    }
}
