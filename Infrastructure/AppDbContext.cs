using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlX.XDevAPI;
using Domain.Entity;
using Infrastructure.Repositorio;

namespace Infrastructure
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Markup> Markups { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=localhost;Database=Gaia;User=gaia;Password=123456;");
            }
        }
    }
}
