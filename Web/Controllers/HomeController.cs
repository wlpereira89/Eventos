using Modelo.PN;
using Modelo.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelo.VM;
using System.Net.Mail;
using System.Threading.Tasks;
namespace Web.Controllers
{

    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            if (pnUsuarios.Logado)
            {
                return RedirectToAction("Menu");
            }

            return View();
        }
        public ActionResult Lista()
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
        public ActionResult Mailing()
        {
            ViewBag.Message = "Enviar Mailling.";

            return View();
        }
        // GET: UsuariosC/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = pnUsuarios.Procurar(id);
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
        public ActionResult Create([Bind(Include = "login,pass,Nome,Endereco,CEP,Nascimento,CPF,RG,email,r_phone,cel_phone,newsletter")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                pnUsuarios.Cadastrar(usuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: UsuariosC/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = pnUsuarios.Procurar(id);
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
                pnUsuarios.Editar(usuario);
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
            usuario usuario = pnUsuarios.Procurar(id);
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
            pnUsuarios.Excluir(id);
            return RedirectToAction("Lista");
        }

        protected override void Dispose(bool disposing)
        {
            pnUsuarios.Dispose(disposing);
            base.Dispose(disposing);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(usuario u)
        {
            // esta action trata o post (login)
            if (ModelState.IsValid) //verifica se é válido
            {

                var v = pnUsuarios.VerificaUsuario(u);
                if (v != null)
                {
                    Session["usuarioLogadoID"] = v.login.ToString();
                    Session["nomeUsuarioLogado"] = v.Nome.ToString();
                    pnUsuarios.Logado = true;
                    return RedirectToAction("Index");
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(vmEmail model)
        //public ActionResult Contact(vmFormularioEmail model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("wagnerluis89@hotmail.com")); //Destinatário
                message.From = new MailAddress("wagnerluis1989@gmail.com"); //Remetente
                message.Subject = "Suporte do Site de Eventos";
                message.Body = string.Format(body, model.FromName, model.FromEmail,
                model.Mensage);
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "stdutfpr@gmail.com", // Seu E-mail
                        Password = "123456LL" // Sua Senha
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Mailing(vmEmail model)
        //public ActionResult Contact(vmFormularioEmail model)
        {
            if (ModelState.IsValid)
            {
                List<usuario> usuarios = pnUsuarios.ListarNews();
                foreach (var user in usuarios)
                {
                    await pnEmail.EnviarMailAsync(model, user.Email);
                }

                return RedirectToAction("Index");                
            }
            return View(model);
        }
    }
}