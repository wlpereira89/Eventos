using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelo.PN;
using Modelo.DAO;

namespace Web.Controllers
{
    public class eventosController : Controller
    {
        private EventosEntities db = new EventosEntities();

        // GET: eventos
        public ActionResult Index()
        {
            return View(pnEventos.Listar());
        }

        // GET: eventos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento evento = pnEventos.Procurar(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // GET: eventos/Create
        public ActionResult Create()
        {
            ViewBag.id_principal = new SelectList(db.evento_composto, "Id", "Nome");
            ViewBag.Responsavel = new SelectList(pnUsuarios.PegarDB(), "login", "Nome");
            return View();
        }

        // POST: eventos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Categoria,id_principal,Nome,Responsavel,palavra_chave,palavra_chave2,limite_participantes,Local,Data")] evento evento)
        {
            if (ModelState.IsValid)
            {
                pnEventos.Cadastrar(evento);
                return RedirectToAction("Index");
            }

            ViewBag.id_principal = new SelectList(db.evento_composto, "Id", "Nome", evento.id_principal);
            ViewBag.Responsavel = new SelectList(pnUsuarios.PegarDB(), "login", "Nome", evento.Responsavel);
            return View(evento);
        }

        // GET: eventos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento evento = pnEventos.Procurar(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_principal = new SelectList(db.evento_composto, "Id", "Nome", evento.id_principal);
            ViewBag.Responsavel = new SelectList(db.usuario, "login", "pass", evento.Responsavel);
            return View(evento);
        }

        // POST: eventos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Categoria,id_principal,Nome,Responsavel,palavra_chave,palavra_chave2,limite_participantes,Local,Data")] evento evento)
        {
            if (ModelState.IsValid)
            {
                pnEventos.Editar(evento);
                return RedirectToAction("Index");
            }
            ViewBag.id_principal = new SelectList(db.evento_composto, "Id", "Nome", evento.id_principal);
            ViewBag.Responsavel = new SelectList(pnUsuarios.PegarDB(), "login", "Nome", evento.Responsavel);
            return View(evento);
        }

        // GET: eventos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento evento = pnEventos.Procurar(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }
        public ActionResult Cancelar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pnEventos.Cancelar(id);
            return RedirectToAction("Index");
        }
        public ActionResult RemoverCancelamento(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pnEventos.RemoverCancelamento(id);
            return RedirectToAction("Index");
        }

        // POST: eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            pnEventos.Excluir(id);
            return RedirectToAction("Index");
        }
        public ActionResult Maps()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            pnEventos.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}
