using Eventos.Data.Modelos; 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.Data.Db
{
    // Eventos.Data/EventosContext.cs
    public class EventosContext : DbContext
    {
        public EventosContext(DbContextOptions<EventosContext> options): base(options) { }

        public DbSet<Evento> Eventos => Set<Evento>();

        public DbSet<Asistente> Asistentes => Set<Asistente>();

        public DbSet<Entrada> Entradas => Set<Entrada>();

        public DbSet<Usuario> Usuarios => Set<Usuario>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }

}
