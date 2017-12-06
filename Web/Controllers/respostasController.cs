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
    public class respostasController : Controller
    {
        private EventosEntities db = new EventosEntities();

        // GET: respostas
        public ActionResult Index()
        {
            var respostas = db.respostas.Include(r => r.pergunta).Include(r => r.usuario1);
            return View(respostas.ToList());
        }

        // GET: respostas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resposta resposta = db.respostas.Find(id);
            if (resposta == null)
            {
                return HttpNotFound();
            }
            return View(resposta);
        }

        // GET: respostas/Create
        public ActionResult Create()
        {
            ViewBag.id_pergunta = new SelectList(db.perguntas, "Id", "pergunta1");
            ViewBag.usuario = new SelectList(db.usuarios, "login", "pass");
            return View();
        }

        // POST: respostas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "usuario,id_pergunta,resposta1")] resposta resposta)
        {
            if (ModelState.IsValid)
            {
                db.respostas.Add(resposta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_pergunta = new SelectList(db.perguntas, "Id", "pergunta1", resposta.id_pergunta);
            ViewBag.usuario = new SelectList(db.usuarios, "login", "pass", resposta.usuario);
            return View(resposta);
        }

        // GET: respostas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resposta resposta = db.respostas.Find(id);
            if (resposta == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_pergunta = new SelectList(db.perguntas, "Id", "pergunta1", resposta.id_pergunta);
            ViewBag.usuario = new SelectList(db.usuarios, "login", "pass", resposta.usuario);
            return View(resposta);
        }

        // POST: respostas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "usuario,id_pergunta,resposta1")] resposta resposta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resposta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_pergunta = new SelectList(db.perguntas, "Id", "pergunta1", resposta.id_pergunta);
            ViewBag.usuario = new SelectList(db.usuarios, "login", "pass", resposta.usuario);
            return View(resposta);
        }

        // GET: respostas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resposta resposta = db.respostas.Find(id);
            if (resposta == null)
            {
                return HttpNotFound();
            }
            return View(resposta);
        }

        // POST: respostas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            resposta resposta = db.respostas.Find(id);
            db.respostas.Remove(resposta);
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
