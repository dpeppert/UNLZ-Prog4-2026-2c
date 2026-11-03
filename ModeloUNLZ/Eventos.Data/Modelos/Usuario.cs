using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eventos.Data.Modelos
{
    public class Usuario
    {
        [Key]
        public int IdPersona { get; set; }
        [Required]
        [MaxLength(200)]
        public string Email { get; set; }
        [MaxLength(200)]
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }
        public List<UsuarioRol> UsuarioRoles { get; set; } = new List<UsuarioRol>();
    }
}
