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

            services.AddScoped<IAereoServico, AereoServico>();
            services.AddScoped<ICarroServico, CarroServico>();
            services.AddScoped<IHotelServico, HotelServico>();
            services.AddScoped<IPacoteServico, PacoteServico>();
            services.AddScoped<IUsuarioServico, UsuarioServico>();
            services.AddScoped<IMarkupServico, MarkupServico>();

            return services;
        }
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAereoRepositorio, AereoRepositorio>();
            services.AddScoped<ICarroRepositorio, CarroRepositorio>();
            services.AddScoped<IHotelRepositorio, HotelRepositorio>();
            services.AddScoped<IPacoteRepositorio, PacoteRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IMarkupRepositorio, MarkupRepositorio>();

            return services;
        }
    }

}
