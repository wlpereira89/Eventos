using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelo.DAO;

namespace Web.Controllers
{
    public class comentariosController : Controller
    {
        private EventosEntities db = new EventosEntities();

        // GET: comentarios
        public ActionResult Index()
        {
            var comentarios = db.comentarios.Include(c => c.evento).Include(c => c.usuario);
            return View(comentarios.ToList());
        }

        // GET: comentarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comentario comentario = db.comentarios.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // GET: comentarios/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.eventoes, "Id", "Nome");
            ViewBag.login = new SelectList(db.usuarios, "login", "pass");
            return View();
        }

        // POST: comentarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,login,id_evento,comentario1,likes")] comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.comentarios.Add(comentario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.eventoes, "Id", "Nome", comentario.Id);
            ViewBag.login = new SelectList(db.usuarios, "login", "pass", comentario.login);
            return View(comentario);
        }

        // GET: comentarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comentario comentario = db.comentarios.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.eventoes, "Id", "Nome", comentario.Id);
            ViewBag.login = new SelectList(db.usuarios, "login", "pass", comentario.login);
            return View(comentario);
        }

        // POST: comentarios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,login,id_evento,comentario1,likes")] comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.eventoes, "Id", "Nome", comentario.Id);
            ViewBag.login = new SelectList(db.usuarios, "login", "pass", comentario.login);
            return View(comentario);
        }

        // GET: comentarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comentario comentario = db.comentarios.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // POST: comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            comentario comentario = db.comentarios.Find(id);
            db.comentarios.Remove(comentario);
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
