using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Eventos.Web.Models
{
    public class EventoVM
    {

        public int IdEvento { get; set; }
        public string NombreEvento { get; set; }
        public DateTime FechaEvento { get; set; }

        public DireccionVM Direccion { get; set; }
        public decimal PrecioEntrada { get; set; }
        public int IdUbicacion { get; set; }
        public List<SelectListItem> Ubicaciones { get; set; }
        public bool EsVip { get; set; }

    }

    public class EventoAltaVM
    {

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(10, ErrorMessage = "Campo con mas de 10 caracteres")]
        public string NombreEvento { get; set; }

        [Required(ErrorMessage = "Campo Requerido")] 
        public DateTime FechaEvento { get; set; }

        public DireccionVM Direccion { get; set; }

        [Range(0,500, ErrorMessage = "El campo no entra dentro del rango,")]
        public decimal PrecioEntrada { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public int IdUbicacion { get; set; }
        public List<SelectListItem> Ubicaciones { get; set; }
        public bool EsVip { get; set; }

    }

    public class DireccionVM
    {

        [Required(ErrorMessage = "Campo Requerido")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public string CodigoPostal { get; set; }


    } 
    public class UbicacionVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
