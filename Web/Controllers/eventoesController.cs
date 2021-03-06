﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelo.DAO;
using Modelo.PN;

namespace Web.Controllers
{
    public class eventoController : Controller
    {
        private EventosEntities db = new EventosEntities();

        public ActionResult Lista()
        {
            return View(pnEventos.Listar());
        }

        // GET: evento
        public ActionResult Index()
        {
            return View(pnEventos.Listar());
        }

        // GET: evento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento evento = db.evento.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // GET: evento/Create
        public ActionResult Create()
        {
            //ViewBag.Id = new SelectList(db.comentarios, "Id", "login");
            ViewBag.id_principal = new SelectList(db.evento_composto, "Id", "Nome");
            ViewBag.Responsavel = new SelectList(db.usuario, "login", "pass");
            return View();
        }

        // POST: evento/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Categoria,id_principal,Nome,Responsavel,Cancelado,palavra_chave,palavra_chave2,limite_participantes,Local,Data,data_hora_fim")] evento evento)
        {
            db.evento.Add(evento);
            db.SaveChanges();
            return RedirectToAction("Index");

            //ViewBag.Id = new SelectList(db.comentarios, "Id", "login", evento.Id);
            ViewBag.id_principal = new SelectList(db.evento_composto, "Id", "Nome", evento.id_principal);
            ViewBag.Responsavel = new SelectList(db.usuario, "login", "pass", evento.Responsavel);
            return View(evento);
        }

        // GET: evento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento evento = db.evento.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Id = new SelectList(db.comentarios, "Id", "login", evento.Id);
            ViewBag.id_principal = new SelectList(db.evento_composto, "Id", "Nome", evento.id_principal);
            ViewBag.Responsavel = new SelectList(db.usuario, "login", "pass", evento.Responsavel);
            return View(evento);
        }

        // POST: evento/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Categoria,id_principal,Nome,Responsavel,Cancelado,palavra_chave,palavra_chave2,limite_participantes,Local,Data,data_hora_fim")] evento evento)
        {
            if (ModelState.IsValid)
            {
                pnEventos.Editar(evento);
                return RedirectToAction("Index");
            }
            //ViewBag.Id = new SelectList(db.comentarios, "Id", "login", evento.Id);
            ViewBag.id_principal = new SelectList(db.evento_composto, "Id", "Nome", evento.id_principal);
            ViewBag.Responsavel = new SelectList(db.usuario, "login", "pass", evento.Responsavel);
            return View(evento);
        }

        // GET: evento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento evento = db.evento.Find(id);
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
        // POST: evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            evento evento = db.evento.Find(id);
            db.evento.Remove(evento);
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
