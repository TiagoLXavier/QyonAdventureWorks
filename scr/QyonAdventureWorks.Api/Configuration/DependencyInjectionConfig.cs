using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using QyonAdventureWorks.Business.Intefaces;
using QyonAdventureWorks.Business.Notificacoes;
using QyonAdventureWorks.Business.Services;
using QyonAdventureWorks.Data.Context;
using QyonAdventureWorks.Data.Repository;

namespace QyonAdventureWorks.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<ICompetidorRepository, CompetidorRepository>();
            services.AddScoped<IHistoricoCorridaRepository, HistoricoCorridaRepository>();
            services.AddScoped<IPistaCorridaRepository, PistaCorridaRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<ICompetidorService, CompetidorService>();
            services.AddScoped<IHistoricoCorridaService, HistoricoCorridaService>();
            services.AddScoped<IPistaCorridaService, PistaCorridaService>();

            return services;
        }
    }
}
