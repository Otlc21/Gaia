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
            services.AddScoped<IAeroportoServico, AeroportoServico>();

            services.AddScoped<ICarroServico, CarroServico>();
            services.AddScoped<ICompanhiaAereaServico, CompanhiaAereaServico>();

            services.AddScoped<IHotelServico, HotelServico>();
            services.AddScoped<ILocalizacaoServico, LocalizacaoServico>();


            services.AddScoped<IMarkupServico, MarkupServico>();
            services.AddScoped<IPacoteServico, PacoteServico>();

            services.AddScoped<IQuartoServico, QuartoServico>();
            services.AddScoped<IUsuarioServico, UsuarioServico>();



            return services;
        }
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAereoRepositorio, AereoRepositorio>();
            services.AddScoped<IAeroportoRepositorio, AeroportoRepositorio>();

            services.AddScoped<ICarroRepositorio, CarroRepositorio>();
            services.AddScoped<ICompanhiaAereaRepositorio, CompanhiaAereaRepositorio>();

            services.AddScoped<IHotelRepositorio, HotelRepositorio>();
            services.AddScoped<ILocalizacaoRepositorio, LocalizacaoRepositorio>();

            services.AddScoped<IMarkupRepositorio, MarkupRepositorio>();

            services.AddScoped<IPacoteRepositorio, PacoteRepositorio>();

            services.AddScoped<IQuartoRepositorio, QuartoRepositorio>();

            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();



            return services;
        }
    }

}
