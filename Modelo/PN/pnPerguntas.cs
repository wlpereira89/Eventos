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
    public class pnPerguntas
    {

        public static List<pergunta> Listar()
        {
            try
            {
                EventosEntities db = new EventosEntities();

                return db.pergunta.Include(p => p.evento).ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static pergunta Procurar(int? id)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                pergunta u = db.pergunta.Find(id);
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


        public static void Cadastrar(pergunta ec)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                db.pergunta.Add(ec);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }


        }
        public static void Editar(pergunta ec)
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
                db.pergunta.Remove(db.pergunta.Find(id));
                db.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }

        }
        public static DbSet<pergunta> PegarDB()
        {
            try
            {
                EventosEntities db = new EventosEntities();
                return db.pergunta;
            }
            catch (Exception)
            {
                throw;
            }

        }
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
