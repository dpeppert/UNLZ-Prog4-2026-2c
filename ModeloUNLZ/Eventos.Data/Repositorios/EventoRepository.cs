using Eventos.Data.Db;
using Eventos.Data.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.Data.Repositorios
{
    public interface IEventoRepository
    {
        void ActualizarEvento(Evento evento);
        bool AgregarEvento(Evento evento);
        bool BorrarEvento(int IdEvento);
        Evento ObtenerEventoPorId(int IdEvento);
        List<Evento> ObtenerEventos();
    }

    public class EventoRepository : IEventoRepository
    {
        private EventosContext _db;

        public EventoRepository(EventosContext context)
        {
            _db = context;
        }

        public bool AgregarEvento(Evento evento)
        {
            try
            {
                _db.Eventos.Add(evento);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return false;
            }
        }

        public List<Evento> ObtenerEventos()
        {
            return _db.Eventos.ToList();
        }

        public Evento ObtenerEventoPorId(int IdEvento)
        { 

            Evento evento = _db.Eventos
                                .Include(x=> x.Asistentes)
                                .Where(x=> x.IdEvento == IdEvento)
                                .FirstOrDefault();


            //Evento evento = _db.Eventos.Where(x=> x.IdEvento == IdEvento).FirstOrDefault(); 
            return evento;
        }

        public void ActualizarEvento(Evento evento)
        {
            _db.Eventos.Update(evento);
            _db.SaveChanges();
        }

        public bool BorrarEvento(int IdEvento)
        {
            try
            {
                Evento evento = _db.Eventos.Find(IdEvento);
                if (evento != null)
                {
                    _db.Eventos.Remove(evento);
                    _db.SaveChanges();
                    return true;
                }
                return false; // Event not found
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return false;
            }
        }

    }
}
