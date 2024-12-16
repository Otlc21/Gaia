using Infraestrutura;
using InjecaoDependencia;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Admin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(@"Log/Log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {

                var builder = WebApplication.CreateBuilder(args);

                builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseMySQL("Server=localhost;Database=Gaia;User=gaia;Password=123456;"));

                builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>();

                // Add services to the container.
                builder.Services.AddControllersWithViews();

                builder.Services.AddDomainServices()
                    .AddInfrastructure(builder.Configuration);

                var app = builder.Build();

                app.UseAuthentication();

                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseStaticFiles();

                app.UseRouting();

                app.UseAuthorization();

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.Warning("Shutting down");
                Log.CloseAndFlush();
            }
        }
    }
}
