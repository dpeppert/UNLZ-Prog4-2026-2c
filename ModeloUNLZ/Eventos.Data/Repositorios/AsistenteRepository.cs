using Eventos.Data.Db;
using Eventos.Data.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.Data.Repositorios
{
    public interface IAsistenteRepository
    {
        bool AgregarAsistente(Asistente asistente);
    }

    public class AsistenteRepository : IAsistenteRepository
    {
        private EventosContext _db;

        public AsistenteRepository(EventosContext db)
        {
            _db = db;
        }
        public bool AgregarAsistente(Asistente asistente)
        {
            try
            {

                var evento = _db.Eventos.Include(e => e.Asistentes)
                            .First(e => e.IdEvento == asistente.IdEvento);
            
                evento.Asistentes.Add(asistente);
                _db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return false;
            }
        }
    }
}
