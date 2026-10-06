using Eventos.Data.Db;
using Eventos.Data.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.Data.Inyecciones
{
    public static class DataAccessExtensions
    {
        public static IServiceCollection AddDataAccess(
            this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<EventosContext>(o =>
                o.UseSqlServer(connectionString));
            services.AddScoped<IEventoRepository, EventoRepository>();

            services.AddScoped<IAsistenteRepository, AsistenteRepository>();
            return services;
        }
    }

}
