using Eventos.Data.Modelos;
using Eventos.Data.Repositorios;
using Eventos.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.Web.Controllers
{
    public class AsistenteController : Controller
    {
        private IAsistenteRepository _repo;

        public AsistenteController (IAsistenteRepository repository)
        {
            _repo = repository;
        }
        [HttpGet("/Eventos/{idEvento:int}/AgregarAsistente")]
        public IActionResult AgregarAEvento(int IdEvento)
        {
//            ViewData["IdEvento"] = IdEvento;
            AsistenteVM asistente = new AsistenteVM();
            asistente.IdEvento = IdEvento;

            return View(asistente);
        }

        [HttpPost("/Asistente/AgregarAsistente")]
        public IActionResult Agregar(AsistenteVM asistente)
        {
            Asistente asistDDBB = new Asistente();
            asistDDBB.Nombre = asistente.Nombre;
            asistDDBB.IdEvento = asistente.IdEvento;
            

            var result = _repo.AgregarAsistente(asistDDBB);

            return View("AgregarAEvento" ,asistDDBB);
        }
    }
}
