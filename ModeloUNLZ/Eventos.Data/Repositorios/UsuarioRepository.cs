using Eventos.Data.Db;
using Eventos.Data.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.Data.Repositorios
{
    public interface IUsuarioRepository
    {
        Usuario ObtenerOCrearUsuario(string email, string nombre);
    }

    public class UsuarioRepository : IUsuarioRepository
    {
        private EventosContext _db;

        public UsuarioRepository(EventosContext db)
        {
            _db = db;
        }

        public Usuario ObtenerOCrearUsuario(string email, string nombre)
        {
            try
            {
                var usuario = _db.Usuarios.FirstOrDefault(u => u.Email == email);
                if (usuario != null)
                {
                    return usuario;
                }

                usuario = new Usuario { Email = email, Nombre = nombre, FechaAlta = DateTime.Now };
                _db.Usuarios.Add(usuario);
                _db.SaveChanges();

                return usuario;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }
    }
}
