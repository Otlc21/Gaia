using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlX.XDevAPI;
using Dominio.Entidade;
using Infraestrutura.Repositorio;

namespace Infraestrutura
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Aereo> Aereos { get; set; }
        public DbSet<Aeroporto> Aeroportos { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<CompanhiaAerea> CompanhiaAereas { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Localizacao> Localizacaos { get; set; }
        public DbSet<Markup> Markups { get; set; }
        public DbSet<Quarto> Quartos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=localhost;Database=Gaia;User=gaia;Password=123456;");
            }
        }
    }
}
