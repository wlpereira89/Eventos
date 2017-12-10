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
    public class pnEventosCompostos
    {
        public static List<evento_composto> Listar()
        {
            try
            {
                EventosEntities db = new EventosEntities();
                return db.evento_composto.ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static evento_composto Procurar(int? id)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                evento_composto u = db.evento_composto.Find(id);
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
       
        
        public static void Cadastrar(evento_composto ec)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                db.evento_composto.Add(ec);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }


        }
        public static void Editar(evento_composto ec)
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
                db.evento_composto.Remove(db.evento_composto.Find(id));
                db.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }

        }
        public static DbSet<evento_composto> PegarDB()
        {
            try
            {
                EventosEntities db = new EventosEntities();
                return db.evento_composto;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}