using Modelo.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Modelo.PN
{
    public class pnParticipantes
    {
        public static List<participante> Listar()
        {
            try
            {
                EventosEntities db = new EventosEntities();
                var participantes = db.participante.Include(p => p.evento).Include(p => p.usuario);
                return participantes.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public static List<usuario> ListarPorEvento(evento e)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                return db.usuario.SqlQuery("SELECT * FROM dbo.usuario JOIN dbo.participante ON participante.login = usuario.login WHERE id_evento =" + e.Id + ";").ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static participante Procurar(string id)
        {
            try
            {
                var ids = id.Split('-');
                EventosEntities db = new EventosEntities();

                var participantes = db.participante.SqlQuery("SELECT * FROM dbo.participante WHERE id_evento="+ids[0]+" AND login='"+ids[1]+"';").ToList();

                if (participantes[0] == null)
                {
                    return null;
                }
                return participantes[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Cadastrar(usuario u)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                db.usuario.Add(u);
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
                var ids = id.Split('-');
                var participantes = db.participante.SqlQuery("SELECT * FROM dbo.participante WHERE id_evento=" + ids[0] + " AND login=" + ids[1] + ";").ToList();

                db.participante.Remove(participantes[0]);
                db.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
