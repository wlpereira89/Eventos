using Modelo.PN;
using Modelo.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
namespace Web.Controllers
{
    
    public class HomeController : Controller
    {
        //EventosEntities db = new EventosEntities();
        public ActionResult Index()
        {
            if (pnUsuarios.Logado)
            {
                return RedirectToAction("Menu");
            }
                
            return View();
        }
        public ActionResult Lista ()
        {
            return View(pnUsuarios.Listar());
        }

        public ActionResult Menu()
        {            
            if (pnUsuarios.Logado)
            {
                return View();
            }
            return RedirectToAction("Index");

        }
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // GET: UsuariosC/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = pnUsuarios.ProcurarUsuario(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: UsuariosC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosC/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "login,pass,Nome,Endereco,CEP,Nascimento,cadastro,CPF,RG,email,r_phone,cel_phone,newsletter")] usuario usuario)
        {
           // if (ModelState.IsValid)
           // {
            db.usuarios.Add(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
           // }

            //return View(usuario);
        }

        // GET: UsuariosC/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: UsuariosC/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "login,pass,Nome,Endereco,CEP,Nascimento,cadastro,CPF,RG,email,r_phone,cel_phone,newsletter")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: UsuariosC/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: UsuariosC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            usuario usuario = db.usuarios.Find(id);
            db.usuarios.Remove(usuario);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(usuario u)
        {
            // esta action trata o post (login)
            if (ModelState.IsValid) //verifica se é válido
            {
                using (EventosEntities dc = new EventosEntities())
                {
                    var v = dc.usuarios.Where(a => a.login.Equals(u.login) && a.pass.Equals(u.pass)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["usuarioLogadoID"] = v.login.ToString();
                        Session["nomeUsuarioLogado"] = v.Nome.ToString();
                        pnUsuarios.Logado = true;

                        return RedirectToAction("Index");
                    }
                }
            }
            return View(u);
        }
        public ActionResult LogOff()
        {
            Session.Clear();
            pnUsuarios.Logado = false;
            return RedirectToAction("Index");
        }
    }
}