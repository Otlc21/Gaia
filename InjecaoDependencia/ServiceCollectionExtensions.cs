using Dominio.Repository;
using Dominio.Service;
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

            services.AddScoped<IFlightService, FlightServico>();
            services.AddScoped<IAirportService, AirportServico>();

            services.AddScoped<ICarService, CarServico>();
            services.AddScoped<IAirlineService, AirlineServico>();

            services.AddScoped<IHotelService, HotelServico>();
            services.AddScoped<ILocationService, LocationServico>();


            services.AddScoped<IMarkupService, MarkupServico>();
            services.AddScoped<IPacoteService, PacoteServico>();

            services.AddScoped<IRoomService, RoomServico>();
            services.AddScoped<IUsuarioService, UsuarioServico>();



            return services;
        }
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFlightRepository, FlightRepositorio>();
            services.AddScoped<IAirportRepository, AirportRepositorio>();

            services.AddScoped<ICarRepository, CarRepositorio>();
            services.AddScoped<IAirlineRepository, AirlineRepositorio>();

            services.AddScoped<IHotelRepository, HotelRepositorio>();
            services.AddScoped<ILocationRepository, LocationRepositorio>();

            services.AddScoped<IMarkupRepository, MarkupRepositorio>();

            services.AddScoped<IPacoteRepository, PacoteRepositorio>();

            services.AddScoped<IRoomRepository, RoomRepositorio>();

            services.AddScoped<IUsuarioRepository, UsuarioRepositorio>();



            return services;
        }
    }

}
