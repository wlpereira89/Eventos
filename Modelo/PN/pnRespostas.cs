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
    public class pnRespostas
    {

        public static List<resposta> Listar()
        {
            try
            {
                EventosEntities db = new EventosEntities();
                return db.resposta.Include(r => r.pergunta).Include(r => r.usuario1).ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static resposta Procurar(int? id)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                resposta u = db.resposta.Find(id);
                if (u == null)
                {
                    return null;
                }
                return u;
            }
            catch (Exception)
            {
                throw;
            }

        }


        public static void Cadastrar(resposta ec)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                db.resposta.Add(ec);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }


        }
        public static void Editar(resposta ec)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                db.Entry(ec).State = EntityState.Modified;
                db.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }

        }
        public static void Excluir(int id)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                db.resposta.Remove(db.resposta.Find(id));
                db.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }

        }
        /*public static DbSet<resposta> PegarDB()
        {
            try
            {
                EventosEntities db = new EventosEntities();
                return db.resposta;
            }
            catch (Exception)
            {
                throw;
            }

        }*/
        public static void Dispose(bool disposing)
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

    }
}
