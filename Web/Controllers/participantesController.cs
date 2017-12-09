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
    public class participantesController : Controller
    {
        private EventosEntities db = new EventosEntities();

        // GET: participantes
        public ActionResult Index()
        {
            
            return View(pnParticipantes.Listar());
        }
        public ActionResult Lpresenca()
        {
            return View(pnParticipantes.Listar());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Lpresenca([Bind(Include = "login,id_evento,Presenca")] participante participante)
        {
            return View(pnParticipantes.Listar());
        }

        // GET: participantes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            participante participante = pnParticipantes.ProcurarParticipante(id);
            if (participante == null)
            {
                return HttpNotFound();
            }
            return View(participante);
        }

        // GET: participantes/Create
        public ActionResult Create()
        {
            ViewBag.id_evento = new SelectList(db.eventoes, "Id", "Id");
            ViewBag.login = new SelectList(db.usuarios, "login", "login");
            return View();
        }

        // POST: participantes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "login,id_evento,Presenca")] participante participante)
        {
            if (ModelState.IsValid)
            {
                db.participantes.Add(participante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_evento = new SelectList(db.eventoes, "Id", "Id", participante.id_evento);
            ViewBag.login = new SelectList(db.usuarios, "login", "login", participante.login);
            return View(participante);
        }

        // GET: participantes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            participante participante = pnParticipantes.ProcurarParticipante(id);
            if (participante == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_evento = new SelectList(db.eventoes, "Id", "Nome", participante.id_evento);
            ViewBag.login = new SelectList(db.usuarios, "login", "pass", participante.login);
            return View(participante);
        }

        // POST: participantes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "login,id_evento,Presenca")] participante participante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_evento = new SelectList(db.eventoes, "Id", "Nome", participante.id_evento);
            ViewBag.login = new SelectList(db.usuarios, "login", "pass", participante.login);
            return View(participante);
        }

        // GET: participantes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            participante participante = pnParticipantes.ProcurarParticipante(id);
            if (participante == null)
            {
                return HttpNotFound();
            }
            return View(participante);
        }

        // POST: participantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            participante participante = pnParticipantes.ProcurarParticipante(id);
            pnParticipantes.Excluir(id);
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
