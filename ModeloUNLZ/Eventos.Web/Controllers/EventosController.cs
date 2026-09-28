using Eventos.Data.Modelos;
using Eventos.Data.Repositorios;
using Eventos.Web.Models;
using Eventos.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Eventos.Web.Controllers
{ 
    public class EventosController : Controller
    {
        private ISumatoriaService _sumatoriaService;
        private IEventoRepository _eventoRepository;

       // public List<EventoVM> eventos { get; set; }
     /*   public List<UbicacionVM> Ubicaciones { get; set; }*/
        public EventosController(ISumatoriaService sumatoriaService, IEventoRepository eventoRepository)
        {
            _sumatoriaService = sumatoriaService;
            _eventoRepository = eventoRepository;


      
            /*
            Ubicaciones = new List<UbicacionVM>();
            Ubicaciones.Add(new UbicacionVM { Id = 1, Nombre = "Movistar Arena" });
            Ubicaciones.Add(new UbicacionVM { Id = 2, Nombre = "El Cilindro" });
            */
        }
        // GET: EventosController
        public ActionResult Index()
        {
            _sumatoriaService.Sumar(1, 2);
            ViewBag.Mensaje = "Inicio";

            List<EventoVM> eventos = new List<EventoVM>();
            var eventosddbb = _eventoRepository.ObtenerEventos();

            eventosddbb = eventosddbb.Where(x => x.Borrado == false).ToList();
            eventos = eventosddbb.Select(x=> new EventoVM { IdEvento = x.IdEvento, FechaEvento = x.FechaEvento, NombreEvento = x.NombreEvento }).ToList();
            return View(eventos);
        }
     
        // GET: EventosController/Details/5
        public ActionResult Details(int id)
        {
            EventoVM elemento = null;

            //elemento = eventos.FirstOrDefault(x => x.IdEvento == id);
            var eventoddb = _eventoRepository.ObtenerEventoPorId(id);
            elemento = new EventoVM { IdEvento = eventoddb.IdEvento, FechaEvento = eventoddb.FechaEvento, NombreEvento = eventoddb.NombreEvento };
            return View(elemento);
        }

        // GET: EventosController/Create
        public ActionResult Create()
        {
            EventoAltaVM evento = new EventoAltaVM();
           /* evento.Ubicaciones = Ubicaciones
                                    .Select(p => new SelectListItem(p.Nombre, p.Id.ToString()))
                                    .ToList();*/
            ViewBag.Mensaje = "";
            return View(evento);
        }

     /*   [HttpGet("ObtenerInformacion/{id:int}")]
        public IActionResult ObtenerInformacionMedianteRuta([FromRoute]int id, [FromQuery] string texto1, [FromQuery]string texto2)
        {

            EventoAltaVM evento = new EventoAltaVM();

            evento.IdUbicacion = 1;
            evento.NombreEvento = "evento1";

            return StatusCode(500);
            // Content("Exitoso");
            // Json(evento);

            return NotFound();
            return View("Index");


        }
     */
        // POST: EventosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventoAltaVM eventoNuevo)
        {
            if (!ModelState.IsValid)
            {
                /*
                eventoNuevo.Ubicaciones = Ubicaciones
                               .Select(p => new SelectListItem(p.Nombre, p.Id.ToString()))
                               .ToList();
                */
                ViewBag.Mensaje = "Error";
              

                return View(eventoNuevo);
            }
           // eventos.Add(eventoNuevo);
            try
            {
                Evento evento = new Evento();

                evento.NombreEvento = eventoNuevo.NombreEvento;
                evento.FechaEvento = eventoNuevo.FechaEvento;

                _eventoRepository.AgregarEvento(evento);
                TempData["Mensaje"] = "Evento creado Exitoso";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventosController/Edit/5
        public ActionResult Edit(int id)
        {
            EventoVM elemento = null;

            var eventoddbb = _eventoRepository.ObtenerEventoPorId(id);
            elemento  = new EventoVM { IdEvento = eventoddbb.IdEvento, FechaEvento = eventoddbb.FechaEvento, NombreEvento = eventoddbb.NombreEvento };  
        

            //            elemento = eventos.FirstOrDefault(x => x.IdEvento == id);

            return View(elemento);
        }

        // POST: EventosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventoVM eventoModificado)
        {
            try
            {
                Evento eventoAModificar = new Evento();
                eventoAModificar.IdEvento = eventoModificado.IdEvento;
                eventoAModificar.NombreEvento = eventoModificado.NombreEvento;
                eventoAModificar.FechaEvento = eventoModificado.FechaEvento;
                _eventoRepository.ActualizarEvento(eventoAModificar);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventosController/Delete/5
        public ActionResult Delete(int id)
        {
            EventoVM elemento = null;

            var eventoddbb = _eventoRepository.ObtenerEventoPorId(id);
            elemento  = new EventoVM { IdEvento = eventoddbb.IdEvento, FechaEvento = eventoddbb.FechaEvento, NombreEvento = eventoddbb.NombreEvento };  
        

            //            elemento = eventos.FirstOrDefault(x => x.IdEvento == id);

            return View(elemento);
        }

        // POST: EventosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var evento = _eventoRepository.ObtenerEventoPorId(id);
                evento.Borrado = true;
                _eventoRepository.ActualizarEvento(evento);
                //_eventoRepository.BorrarEvento(id);
                //eventos.Remove(eventos.First(x => x.IdEvento == id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
