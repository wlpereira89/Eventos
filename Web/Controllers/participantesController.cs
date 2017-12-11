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
using Modelo.VM;

namespace Web.Controllers
{
    public class participantesController : Controller
    {
        //private EventosEntities db = new EventosEntities();

        // GET: participantes
        public ActionResult Index()
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
            participante participante = pnParticipantes.Procurar(id);
            if (participante == null)
            {
                return HttpNotFound();
            }
            return View(participante);
        }


        // GET: participantes/Create
        public ActionResult Create()
        {
            ViewBag.id_evento = new SelectList(pnEventos.PegarDB(), "Id", "Nome");
            ViewBag.login = new SelectList(pnEventos.PegarDB(), "login", "Nome");
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
                pnParticipantes.Cadastrar(participante);
                return RedirectToAction("Index");
            }

            ViewBag.id_evento = new SelectList(pnEventos.PegarDB(), "Id", "Nome", participante.id_evento);
            ViewBag.login = new SelectList(pnEventos.PegarDB(), "login", "Nome", participante.login);
            return View(participante);
        }

        // GET: participantes/Edit/5
        public ActionResult Presente(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pnParticipantes.Presente(id);
            
            return RedirectToAction("Index");
        }
        public ActionResult Ausente(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pnParticipantes.Ausente(id);
            return RedirectToAction("Index");
        }
        public ActionResult Certificado(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] dados = pnParticipantes.VerificarCertificado(id);
            if (dados==null)
            {
                return RedirectToAction("NaoEmitido");
            }
            usuario u = pnUsuarios.Procurar(dados[1]);
            evento ev = pnEventos.Procurar(Convert.ToInt32(dados[0]));
            vmCertificado v = new vmCertificado();
            v.nomeEvento = ev.Nome;
            v.nomeUsuario = u.Nome;
            v.data = ev.Data;
            return View(v);            
        }
        // POST: participantes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.


        // GET: participantes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            participante participante = pnParticipantes.Procurar(id);
            if (participante == null)
            {
                return HttpNotFound();
            }
            return View(participante);
        }
        public ActionResult NaoEmitido()
        {
            return View();
        }
        // POST: participantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            participante participante = pnParticipantes.Procurar(id);
            pnParticipantes.Excluir(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            pnParticipantes.Dispose(disposing);            
            base.Dispose(disposing);
        }
    }
}
