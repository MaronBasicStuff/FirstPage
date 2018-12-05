using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1;

namespace WebApplication1.Controllers
{
    public class AnunciosController : Controller
    {
        private FirstPageEntities db = new FirstPageEntities();

        // GET: Anuncios
        public ActionResult Index()
        {
            return View(db.Anuncios.ToList());
            //return Session["usuarioID"].ToString();
            // db.Usuarios.FirstOrDefault(u => u.UsuarioID == (int)Session["usuarioID"])
        }

        // GET: Anuncios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(Session["usuarioID"]);
            Anuncio anuncio = db.Anuncios.Find(id);
            
            
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            return View(anuncio);
        }

        public ActionResult AnunciosAdmin()
        {
            return View(db.Anuncios.ToList());
            //return Session["usuarioID"].ToString();
            // db.Usuarios.FirstOrDefault(u => u.UsuarioID == (int)Session["usuarioID"])
        }

        public ActionResult Search(string searchElement)
        {
            var searchEl = from s in db.Anuncios select s;
            if (!String.IsNullOrEmpty(searchElement))
            {
                searchEl = searchEl.Where(c => c.Entrada.Contains(searchElement));
            }
            return View(searchEl);
        }

        // GET: Anuncios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Anuncios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Anuncio anuncio, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(file.FileName));
                file.SaveAs(path);
                db.Anuncios.Add(new Anuncio
                {
                    Foto = "~/Images/" + file.FileName,
                    PostID = anuncio.PostID,
                    Entrada = anuncio.Entrada,
                    Precio = anuncio.Precio,
                    Descript = anuncio.Descript,
                    Located = anuncio.Located,
                    Fecha = anuncio.Fecha,
                    UsuarioID = (int) Session["usuarioID"]

                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anuncio);
        }

        // GET: Anuncios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            return View(anuncio);
        }

        // POST: Anuncios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostID,Entrada,Precio,Descript,Located,Fecha,UsuarioID,Foto")] Anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anuncio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anuncio);
        }

        // GET: Anuncios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            return View(anuncio);
        }

        // POST: Anuncios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anuncio anuncio = db.Anuncios.Find(id);
            db.Anuncios.Remove(anuncio);
            db.SaveChanges();
            return RedirectToAction("Index");
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
