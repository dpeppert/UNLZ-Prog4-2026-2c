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
        List<String> ObtenerAcciones(string email);
        
    }

    public class UsuarioRepository : IUsuarioRepository
    {
        private EventosContext _db;

        public UsuarioRepository(EventosContext db)
        {
            _db = db;
        }
        public List<String> ObtenerAcciones(string Email)
        {
            try
            {
                var usuario = _db.Usuarios.Include(u => u.UsuarioRoles)
                                           .ThenInclude(ur => ur.Rol)
                                           .ThenInclude(r => r.RolesAcciones)
                                           .ThenInclude(ra => ra.Accion)
                                           .FirstOrDefault(u => u.Email == Email);
                if (usuario == null)
                {
                    return new List<string>();
                }
                var acciones = usuario.UsuarioRoles
                                      .SelectMany(ur => ur.Rol.RolesAcciones)
                                      .Select(ra => ra.Accion.Descripcion)
                                      .Distinct()
                                      .ToList();
                return acciones;
            }
            catch (Exception ex)
            {

                return new List<string>();
            }
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
