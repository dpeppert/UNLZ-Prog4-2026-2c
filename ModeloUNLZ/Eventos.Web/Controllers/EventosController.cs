using Eventos.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.Web.Controllers
{
    public class EventosController : Controller
    {
        public List<EventoVM> eventos { get; set; }
        public EventosController()
        {
           eventos = new List<EventoVM>();

            eventos.Add(new EventoVM { IdEvento = 1, FechaEvento = DateTime.Now, NombreEvento = "Racing - Boca" });

            eventos.Add(new EventoVM { IdEvento = 2, FechaEvento = DateTime.Now, NombreEvento = "Estudiantes - Ferro" });

        }
        // GET: EventosController
        public ActionResult Index()
        {
            
            return View(eventos);
        }

        // GET: EventosController/Details/5
        public ActionResult Details(int id)
        {
            EventoVM elemento = null;

            elemento = eventos.FirstOrDefault(x => x.IdEvento == id);

            return View(elemento);
        }

        // GET: EventosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventoVM eventoNuevo)
        {

            eventos.Add(eventoNuevo);
            try
            {
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

            elemento = eventos.FirstOrDefault(x => x.IdEvento == id);


            return View(elemento);
        }

        // POST: EventosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventoVM eventoModificado)
        {
            try
            {
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

            elemento = eventos.FirstOrDefault(x => x.IdEvento == id);

            return View(elemento);
        }

        // POST: EventosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {

                eventos.Remove(eventos.First(x => x.IdEvento == id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
