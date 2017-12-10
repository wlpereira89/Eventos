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
    public class respostasController : Controller
    {
       // private EventosEntities db = new EventosEntities();

        // GET: respostas
        public ActionResult Index()
        {
            
            return View(pnRespostas.Listar());
        }

        // GET: respostas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resposta resposta = pnRespostas.Procurar(id);
            if (resposta == null)
            {
                return HttpNotFound();
            }
            return View(resposta);
        }

        // GET: respostas/Create
        public ActionResult Create()
        {
            ViewBag.id_pergunta = new SelectList(pnPerguntas.PegarDB(), "Id", "pergunta1");
            ViewBag.usuario = new SelectList(pnUsuarios.PegarDB(), "login", "pass");
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
                pnRespostas.Cadastrar(resposta);
                return RedirectToAction("Index");
            }

            ViewBag.id_pergunta = new SelectList(pnPerguntas.PegarDB(), "Id", "pergunta1", resposta.id_pergunta);
            ViewBag.usuario = new SelectList(pnUsuarios.PegarDB(), "login", "pass", resposta.usuario);
            return View(resposta);
        }

        // GET: respostas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resposta resposta = pnRespostas.Procurar(id);
            if (resposta == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_pergunta = new SelectList(pnPerguntas.PegarDB(), "Id", "pergunta1", resposta.id_pergunta);
            ViewBag.usuario = new SelectList(pnUsuarios.PegarDB(), "login", "pass", resposta.usuario);
            return View(resposta);
        }

        // POST: respostas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, usuario,id_pergunta,resposta1")] resposta resposta)
        {
            if (ModelState.IsValid)
            {
                pnRespostas.Editar(resposta);
                return RedirectToAction("Index");
            }
            ViewBag.id_pergunta = new SelectList(pnPerguntas.PegarDB(), "Id", "pergunta1", resposta.id_pergunta);
            ViewBag.usuario = new SelectList(pnUsuarios.PegarDB(), "login", "pass", resposta.usuario);
            return View(resposta);
        }

        // GET: respostas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resposta resposta = pnRespostas.Procurar(id);
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
            pnRespostas.Excluir(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            pnRespostas.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}
