using Modelo.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Modelo.PN
{

    public class pnEventos
    {
        public static DbSet<evento> PegarDB()
        {
            try
            {
                EventosEntities db = new EventosEntities();
                return db.eventoes;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static List<evento> Listar()
        {
            try
            {
                EventosEntities db = new EventosEntities();
                return db.eventoes.ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public static evento Procurar(string id)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                evento e = db.eventoes.Find(id);
                if (e == null)
                {
                    return null;
                }
                return e;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static void Cadastrar(evento e)
        {
            try
            {                
                EventosEntities db = new EventosEntities();
                db.eventoes.Add(e);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }


        }
        public static void Editar(evento e)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                db.Entry(e).State = EntityState.Modified;
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

                db.eventoes.Remove(db.eventoes.Find(id));
                db.SaveChanges();

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
