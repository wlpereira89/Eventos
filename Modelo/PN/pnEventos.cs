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
                return db.evento;
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
                var evento = db.evento.Include(e => e.comentario).Include(e => e.evento_composto).Include(e => e.usuario);
                return db.evento.ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public static evento Procurar(int? id)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                evento e = db.evento.Find(id);
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
                e.Cancelado = false;
                e.emitidos = false;
                EventosEntities db = new EventosEntities();
                db.evento.Add(e);
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
        public static void Cancelar(int? id)
        {
            try
            {                
                EventosEntities db = new EventosEntities();
                evento e = db.evento.Find(id);
                if (e.Data > DateTime.Now)
                {
                    e.Cancelado = true;
                    db.Entry(e).State = EntityState.Modified;
                    db.SaveChanges();
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
        public static void Emitir(int? id)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                evento e = db.evento.Find(id);
                if (e.Data <= DateTime.Now)
                {
                    e.emitidos = true;
                    db.Entry(e).State = EntityState.Modified;
                    db.SaveChanges();
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
        public static void RemoverCancelamento(int? id)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                evento e = db.evento.Find(id);
                e.Cancelado = false;
                db.Entry(e).State = EntityState.Modified;
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

                db.evento.Remove(db.evento.Find(id));
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
