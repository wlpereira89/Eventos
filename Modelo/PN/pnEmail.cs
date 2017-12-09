using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.VM;
using System.Net.Mail;
using System.Net;

namespace Modelo.PN
{
    public class pnEmail
    {
        public static async Task EnviarMailAsync(vmEmail model, string para)
        //public ActionResult Contact(vmFormularioEmail model)
        {          
            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress(para)); //Destinatário
            message.From = new MailAddress("wagnerluis1989@gmail.com"); //Remetente
            message.Subject = "Suporte do Site de Eventos";
            message.Body = string.Format(body, model.FromName, model.FromEmail,
            model.Mensage);
            message.IsBodyHtml = true;
            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "wagnerluis1989@gmail.com", // Seu E-mail
                    Password = "rq5i6mer" // Sua Senha
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }
        }
        
    }
}
