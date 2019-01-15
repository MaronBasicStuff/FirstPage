using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(Usuario usuarioModel)
        {
            using (FirstPageEntities db = new FirstPageEntities())
            {
              var userDetails = db.Usuarios.Where(x => x.Email == usuarioModel.Email && x.Pass == usuarioModel.Pass).FirstOrDefault();
                if (userDetails == null)
                {
                    usuarioModel.LoginErrorMessage = "incorrecto";
                    return View("Index", usuarioModel);
               }
                else
                {

                    Session["usuarioID"] = userDetails.UsuarioID;
                    Session["email"] = userDetails.Email;


                    return RedirectToAction("Index", "Anuncios");

                }
            }
        }

        public ActionResult LogOut()
        {
            int usuarioID = (int)Session["usuarioId"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}