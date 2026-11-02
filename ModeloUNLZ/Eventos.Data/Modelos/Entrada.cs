using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Eventos.Data.Modelos
{
    public class Entrada
    {
        [Key]
        public int IdEntrada { get; set; }
        public int IdEvento { get; set; }
        [ForeignKey(nameof(IdEvento))]
        public Evento Evento { get; set; }
        public int IdPersona { get; set; }
        [ForeignKey(nameof(IdPersona))]
        public Usuario Persona { get; set; }
        public DateTime FechaCompra { get; set; }
    }
}
