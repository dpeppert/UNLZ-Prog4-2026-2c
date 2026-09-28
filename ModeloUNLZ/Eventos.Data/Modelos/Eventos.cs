using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Eventos.Data.Modelos
{
    public class Evento
    {
        [Key]
        public int IdEvento { get; set; }
        [Required]
        [StringLength(100)]
        public string NombreEvento { get; set; }
        [Column(TypeName = "Date")]
        public DateTime FechaEvento { get; set; }

        [Column(TypeName = "bit")]
        public bool Borrado { get; set; }
    }
}
