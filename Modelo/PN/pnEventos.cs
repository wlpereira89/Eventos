using Modelo.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.PN
{
    public class pnEventos
    {
        public static bool Logado { get; set; }
        public static List<usuario> Listar()
        {
            try
            {
            EventosEntities db = new EventosEntities();
            return (db.usuarios.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*public static bool Registrar(usuario u)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                usuario user = new usuario();
                //para mexer em um registro fazer a leitura de campo
                user = db.usuarios.Find(u.CPF);// CONFERIR
                user.login = u.login;
                user.pass = u.pass;
                user.Nome = u.login;
                user.Endereco = u.Endereco;
                user.CEP = u.CEP;
                user.Nascimento = u.Nascimento;
                user.cadastro = u.cadastro;
                user.CPF = u.CPF;
                user.RG = u.RG;
                user.r_phone = u.r_phone;
                user.cel_phone = u.cel_phone;
                user.newsletter = u.newsletter;

                db.Entry(u);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public usuario findbByCPF(int CPF)
        {
            try
            {
                EventosEntities db = new EventosEntities();

                //EventosEntities db = new EventosEntities();
                return db.usuarios.Find(CPF);

            }
            catch (Exception)
            {
                throw;
            }
        }*/
        
    }
}
