using Eventos.Data.Repositorios;
using Eventos.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.Web.Controllers
{
    [Authorize]
    public class EntradasCompradasController : Controller
    {
        private IEntradaRepository _repo;

        public EntradasCompradasController(IEntradaRepository repository)
        {
            _repo = repository;
        }

        // GET: EntradasCompradas
        public IActionResult Index()
        {
            var entradasddbb = _repo.ObtenerTodasLasEntradas();

            List<EntradaCompradaVM> entradas = entradasddbb.Select(x => new EntradaCompradaVM
            {
                IdEntrada = x.IdEntrada,
                NombreEvento = x.Evento.NombreEvento,
                FechaEvento = x.Evento.FechaEvento,
                NombreComprador = x.Persona.Nombre,
                EmailComprador = x.Persona.Email,
                FechaCompra = x.FechaCompra
            }).ToList();
            return View(entradas);
        }
    }
}
