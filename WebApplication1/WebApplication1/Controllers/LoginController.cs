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
        public ActionResult Authorize(WebApplication1.Models.Usuario usuarioModel)
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
                    Session["userID"] = userDetails.UsuarioID;
                    return RedirectToAction("Index", "Home");
               
                }
                return View();
            }
        }
    }
}