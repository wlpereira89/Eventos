using System;
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
    public class evento_compostoController : Controller
    {
        private EventosEntities db = new EventosEntities();


        public ActionResult Lista()
        {
            return View(pnEventosCompostos.Listar());
        }

        // GET: evento_composto
        public ActionResult Index()
        {
            return View(pnEventosCompostos.Listar());
        }

        // GET: evento_composto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento_composto evento_composto = pnEventosCompostos.Procurar(id);
            if (evento_composto == null)
            {
                return HttpNotFound();
            }
            return View(evento_composto);
        }

        // GET: evento_composto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: evento_composto/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome")] evento_composto evento_composto)
        {
            if (ModelState.IsValid)
            {
                pnEventosCompostos.Cadastrar(evento_composto);
                return RedirectToAction("Index");
            }

            return View(evento_composto);
        }

        // GET: evento_composto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento_composto evento_composto = pnEventosCompostos.Procurar(id);
            if (evento_composto == null)
            {
                return HttpNotFound();
            }
            return View(evento_composto);
        }

        // POST: evento_composto/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Nome")] evento_composto evento_composto)
        {
            if (ModelState.IsValid)
            {
                pnEventosCompostos.Editar(evento_composto);
                return RedirectToAction("Index");
            }
            return View(evento_composto);
        }

        // GET: evento_composto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento_composto evento_composto = pnEventosCompostos.Procurar(id);
            if (evento_composto == null)
            {
                return HttpNotFound();
            }
            return View(evento_composto);
        }

        // POST: evento_composto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pnEventosCompostos.Excluir(id);
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
