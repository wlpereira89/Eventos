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
    public class perguntasController : Controller
    {
        private EventosEntities db = new EventosEntities();

        // GET: perguntas
        public ActionResult Index()
        {
            var perguntas = db.perguntas.Include(p => p.evento);
            return View(perguntas.ToList());
        }

        // GET: perguntas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pergunta pergunta = db.perguntas.Find(id);
            if (pergunta == null)
            {
                return HttpNotFound();
            }
            return View(pergunta);
        }

        // GET: perguntas/Create
        public ActionResult Create()
        {
            ViewBag.id_evento = new SelectList(db.eventoes, "Id", "Nome");
            return View();
        }

        // POST: perguntas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,id_evento,pergunta1")] pergunta pergunta)
        {
            if (ModelState.IsValid)
            {
                db.perguntas.Add(pergunta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_evento = new SelectList(db.eventoes, "Id", "Nome", pergunta.id_evento);
            return View(pergunta);
        }

        // GET: perguntas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pergunta pergunta = db.perguntas.Find(id);
            if (pergunta == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_evento = new SelectList(db.eventoes, "Id", "Nome", pergunta.id_evento);
            return View(pergunta);
        }

        // POST: perguntas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,id_evento,pergunta1")] pergunta pergunta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pergunta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_evento = new SelectList(db.eventoes, "Id", "Nome", pergunta.id_evento);
            return View(pergunta);
        }

        // GET: perguntas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pergunta pergunta = db.perguntas.Find(id);
            if (pergunta == null)
            {
                return HttpNotFound();
            }
            return View(pergunta);
        }

        // POST: perguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pergunta pergunta = db.perguntas.Find(id);
            db.perguntas.Remove(pergunta);
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
