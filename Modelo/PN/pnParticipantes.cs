﻿using Modelo.DAO;
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

                var participantes = db.participante.SqlQuery("SELECT * FROM dbo.participante WHERE id_evento=" + ids[0] + " AND login='" + ids[1] + "';").ToList();

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
        public static string[] VerificarCertificado(string id)
        {
            try
            {
                var ids = id.Split('-');
                EventosEntities db = new EventosEntities();                
                var participantes = db.participante.SqlQuery("SELECT * FROM dbo.participante WHERE id_evento=" + ids[0] + " AND login='" + ids[1] + "';").ToList();
                evento ev = pnEventos.Procurar(Convert.ToInt32(ids[0]));
                if ((participantes[0] == null) || (ev.emitidos!=true))
                {
                    return null;
                }
                return ids;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Cadastrar(participante part)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                db.participante.Add(part);
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
        public static void Presente(string id)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                var ids = id.Split('-');
                var participantes = db.participante.SqlQuery("SELECT * FROM dbo.participante WHERE id_evento=" + ids[0] + " AND login='" + ids[1] + "';").ToList();
                participantes[0].Presenca = true;
                db.Entry(participantes[0]).State = EntityState.Modified;
                db.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }

        }
        public static void Ausente(string id)
        {
            try
            {
                EventosEntities db = new EventosEntities();
                var ids = id.Split('-');
                var participantes = db.participante.SqlQuery("SELECT * FROM dbo.participante WHERE id_evento=" + ids[0] + " AND login='" + ids[1] + "';").ToList();
                participantes[0].Presenca = false;
                db.Entry(participantes[0]).State = EntityState.Modified;
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
