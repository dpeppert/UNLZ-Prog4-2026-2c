using Eventos.Data.Modelos;
using Eventos.Data.Repositorios;
using Eventos.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Eventos.Web.Controllers
{
    [Authorize]
    public class EntradaController : Controller
    {
        private IEntradaRepository _repo;
        private IEventoRepository _eventoRepository;
        private IUsuarioRepository _usuarioRepository;

        public EntradaController(IEntradaRepository repository, IEventoRepository eventoRepository, IUsuarioRepository usuarioRepository)
        {
            _repo = repository;
            _eventoRepository = eventoRepository;
            _usuarioRepository = usuarioRepository;
        }

        private Usuario ObtenerUsuarioLogueado()
        {
            return _usuarioRepository.ObtenerOCrearUsuario(
                User.FindFirstValue(ClaimTypes.Email),
                User.FindFirstValue(ClaimTypes.Name));
        }

        // GET: Entrada
        public IActionResult Index()
        {
            var eventosddbb = _eventoRepository.ObtenerEventos().Where(x => x.Borrado == false).ToList();
            List<EventoVM> eventos = eventosddbb.Select(x => new EventoVM { IdEvento = x.IdEvento, FechaEvento = x.FechaEvento, NombreEvento = x.NombreEvento }).ToList();
            return View(eventos);
        }

        // GET: Entrada/Comprar/5
        [HttpGet("/Entrada/Comprar/{idEvento:int}")]
        public IActionResult Comprar(int idEvento)
        {
            var eventoddbb = _eventoRepository.ObtenerEventoPorId(idEvento);
            if (eventoddbb == null || eventoddbb.Borrado)
            {
                return NotFound();
            }

            EntradaVM entrada = new EntradaVM
            {
                IdEvento = eventoddbb.IdEvento,
                NombreEvento = eventoddbb.NombreEvento,
                FechaEvento = eventoddbb.FechaEvento
            };
            return View(entrada);
        }

        // POST: Entrada/Comprar
        [HttpPost("/Entrada/Comprar")]
        [ValidateAntiForgeryToken]
        public IActionResult ComprarConfirmado(EntradaVM entrada)
        {
            var usuario = ObtenerUsuarioLogueado();

            Entrada entradaDDBB = new Entrada();
            entradaDDBB.IdEvento = entrada.IdEvento;
            entradaDDBB.IdPersona = usuario?.IdPersona ?? 0;

            var result = usuario != null && _repo.ComprarEntrada(entradaDDBB);

            if (!result)
            {
                TempData["Mensaje"] = "No se pudo comprar la entrada";
                return RedirectToAction(nameof(Index));
            }

            TempData["Mensaje"] = "Entrada comprada Exitoso";
            return RedirectToAction(nameof(MisEntradas));
        }

        // GET: Entrada/MisEntradas
        public IActionResult MisEntradas()
        {
            var usuario = ObtenerUsuarioLogueado();
            var entradasddbb = _repo.ObtenerEntradasPorPersona(usuario.IdPersona);

            List<EntradaVM> entradas = entradasddbb.Select(x => new EntradaVM
            {
                IdEntrada = x.IdEntrada,
                IdEvento = x.IdEvento,
                NombreEvento = x.Evento.NombreEvento,
                FechaEvento = x.Evento.FechaEvento,
                FechaCompra = x.FechaCompra
            }).ToList();
            return View(entradas);
        }
    }
}
