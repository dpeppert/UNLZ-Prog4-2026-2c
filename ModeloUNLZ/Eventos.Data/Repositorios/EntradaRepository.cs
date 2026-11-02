using Eventos.Data.Db;
using Eventos.Data.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.Data.Repositorios
{
    public interface IEntradaRepository
    {
        bool ComprarEntrada(Entrada entrada);
        List<Entrada> ObtenerEntradasPorPersona(int idPersona);
        List<Entrada> ObtenerTodasLasEntradas();
    }

    public class EntradaRepository : IEntradaRepository
    {
        private EventosContext _db;

        public EntradaRepository(EventosContext db)
        {
            _db = db;
        }

        public bool ComprarEntrada(Entrada entrada)
        {
            try
            {
                var evento = _db.Eventos.FirstOrDefault(e => e.IdEvento == entrada.IdEvento && !e.Borrado);
                if (evento == null)
                {
                    return false; 
                }

                entrada.FechaCompra = DateTime.Now;
                _db.Entradas.Add(entrada);
                _db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

        public List<Entrada> ObtenerTodasLasEntradas()
        {
            return _db.Entradas
                        .Include(x => x.Evento)
                        .Include(x => x.Persona)
                        .OrderByDescending(x => x.FechaCompra)
                        .ToList();
        }

        public List<Entrada> ObtenerEntradasPorPersona(int idPersona)
        {
            return _db.Entradas
                        .Include(x => x.Evento)
                        .Where(x => x.IdPersona == idPersona)
                        .OrderByDescending(x => x.FechaCompra)
                        .ToList();
        }
    }
}
