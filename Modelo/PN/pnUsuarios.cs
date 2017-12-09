using Modelo.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.PN
{
    public class pnUsuarios
    {
        /* public static usuario ProcurarUsuario(string id)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                
            }
            catch (Exception)
            {
                throw;
            }

        }*/
         
         
        public static bool Logado { get; set; } = false;
        public static List<usuario> Listar()
        {
            try
            {
                EventosEntities db = new EventosEntities();
                return db.usuarios.ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static List<usuario> ListarNews()
        {
            try
            {
                EventosEntities db = new EventosEntities();
                
                return db.usuarios.SqlQuery("SELECT * FROM dbo.usuario WHERE newsletter=1;").ToList(); 
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static usuario ProcurarUsuario(string id)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                usuario usuario = db.usuarios.Find(id);
                if (usuario == null)
                {
                    return null;
                }
                return usuario;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static void CadastrarUsuario(usuario u)
        {
            try
            {
                u.cadastro = DateTime.Now;
                EventosEntities db = new EventosEntities();
                db.usuarios.Add(u);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }


        }
        public static void Editar(usuario u)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                db.Entry(u).State = EntityState.Modified;
                db.SaveChanges();
                    
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public static void Excluir(string id)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                
                db.usuarios.Remove(db.usuarios.Find(id));
                db.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }

        }
        public static void Dispose (bool disposing)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                if (disposing)
                {
                    db.Dispose();
                }               

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static usuario VerificaUsuario(usuario u)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                return db.usuarios.Where(a => a.login.Equals(u.login) && a.pass.Equals(u.pass)).FirstOrDefault();

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
