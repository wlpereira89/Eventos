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
    public class eventoesController : Controller
    {
        private EventosEntities db = new EventosEntities();

        public ActionResult Lista()
        {
            return View(db.eventoes.ToList());
        }

        // GET: eventoes
        public ActionResult Index()
        {
            var eventoes = db.eventoes.Include(e => e.comentarios).Include(e => e.evento_composto).Include(e => e.usuario);
            return View(eventoes.ToList());
        }

        // GET: eventoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento evento = db.eventoes.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // GET: eventoes/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.comentarios, "Id", "login");
            ViewBag.id_principal = new SelectList(db.evento_composto, "Id", "Nome");
            ViewBag.Responsavel = new SelectList(db.usuarios, "login", "pass");
            return View();
        }

        // POST: eventoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Categoria,id_principal,Nome,Responsavel,Cancelado,palavra_chave,palavra_chave2,limite_participantes,Local,data_hr_ini,data_hora_fim")] evento evento)
        {
            db.eventoes.Add(evento);
            db.SaveChanges();
            return RedirectToAction("Index");

            ViewBag.Id = new SelectList(db.comentarios, "Id", "login", evento.Id);
            ViewBag.id_principal = new SelectList(db.evento_composto, "Id", "Nome", evento.id_principal);
            ViewBag.Responsavel = new SelectList(db.usuarios, "login", "pass", evento.Responsavel);
            return View(evento);
        }

        // GET: eventoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento evento = db.eventoes.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.comentarios, "Id", "login", evento.Id);
            ViewBag.id_principal = new SelectList(db.evento_composto, "Id", "Nome", evento.id_principal);
            ViewBag.Responsavel = new SelectList(db.usuarios, "login", "pass", evento.Responsavel);
            return View(evento);
        }

        // POST: eventoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Categoria,id_principal,Nome,Responsavel,Cancelado,palavra_chave,palavra_chave2,limite_participantes,Local,data_hr_ini,data_hora_fim")] evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.comentarios, "Id", "login", evento.Id);
            ViewBag.id_principal = new SelectList(db.evento_composto, "Id", "Nome", evento.id_principal);
            ViewBag.Responsavel = new SelectList(db.usuarios, "login", "pass", evento.Responsavel);
            return View(evento);
        }

        // GET: eventoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento evento = db.eventoes.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        public ActionResult Maps()
        {
            return View();
        }
        // POST: eventoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            evento evento = db.eventoes.Find(id);
            db.eventoes.Remove(evento);
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
