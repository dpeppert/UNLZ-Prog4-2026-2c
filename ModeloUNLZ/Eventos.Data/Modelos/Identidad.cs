using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eventos.Data.Modelos
{

    public class UsuarioRol
    {
        [Key]
        public int IdUsuarioRol { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int IdRol { get; set; }
        public Rol Rol { get; set; }
    }

    public class Rol
    {
        [Key]
        public int IdRol { get; set; }
        public string Descripcion { get; set; }
        public List<RolAccion> RolesAcciones { get; set; } = new List<RolAccion>();


    }



    public class RolAccion
    {
        [Key]
        public int IdRolAccion { get; set; }
        public int IdRol { get; set; }
        public Rol Rol { get; set; }
        public int IdAccion { get; set; }
        public Accion Accion { get; set; }
    }

    public class Accion
    {
        [Key]
        public int IdAccion { get; set; }
        public string Descripcion { get; set; }
    }

}
