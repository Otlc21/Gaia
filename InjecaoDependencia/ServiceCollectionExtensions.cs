using Dominio.Repositorio;
using Dominio.Servico;
using Infraestrutura.Repositorio;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegraNegocio.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjecaoDependencia
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {

            services.AddScoped<IFlightServico, FlightServico>();
            services.AddScoped<IAirportServico, AirportServico>();

            services.AddScoped<ICarServico, CarServico>();
            services.AddScoped<IAirlineServico, AirlineServico>();

            services.AddScoped<IHotelServico, HotelServico>();
            services.AddScoped<ILocationServico, LocationServico>();


            services.AddScoped<IMarkupServico, MarkupServico>();
            services.AddScoped<IPacoteServico, PacoteServico>();

            services.AddScoped<IRoomServico, RoomServico>();
            services.AddScoped<IUsuarioServico, UsuarioServico>();



            return services;
        }
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFlightRepositorio, FlightRepositorio>();
            services.AddScoped<IAirportRepositorio, AirportRepositorio>();

            services.AddScoped<ICarRepositorio, CarRepositorio>();
            services.AddScoped<IAirlineRepositorio, AirlineRepositorio>();

            services.AddScoped<IHotelRepositorio, HotelRepositorio>();
            services.AddScoped<ILocationRepositorio, LocationRepositorio>();

            services.AddScoped<IMarkupRepositorio, MarkupRepositorio>();

            services.AddScoped<IPacoteRepositorio, PacoteRepositorio>();

            services.AddScoped<IRoomRepositorio, RoomRepositorio>();

            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();



            return services;
        }
    }

}
