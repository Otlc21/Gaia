using BL.Service;
using Domain.Client;
using Domain.Repository;
using Domain.Service;
using Infrastructure.Client;
using Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainService(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();

            services.AddScoped<IFlightService, FlightService>();

            services.AddScoped<IHotelService, HotelService>();

            services.AddScoped<IMarkupService, MarkupService>();

            services.AddScoped<IUserService, UserService>();

            return services;
        }
        
        public static IServiceCollection AddClient(this IServiceCollection services)
        {
            services.AddScoped<IEmailClient, EmailClient>();

            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICarRepository, CarRepository>();

            services.AddScoped<IFlightRepository, FlightRepository>();

            services.AddScoped<IHotelRepository, HotelRepository>();

            services.AddScoped<IMarkupRepository, MarkupRepository>();

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }

}
