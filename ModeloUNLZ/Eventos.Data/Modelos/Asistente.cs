using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eventos.Data.Modelos
{
    public class Asistente
    {
        [Key]
        public int IdAsistente { get; set; }
        [MaxLength(200)]
        public string Nombre { get; set; }
        public int IdEvento { get; set; }
        public Evento Evento { get; set; }
    }
}
