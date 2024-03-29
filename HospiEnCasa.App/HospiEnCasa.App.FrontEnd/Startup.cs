using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HospiEnCasa.App.Persistencia.Models;
using HospiEnCasa.App.Persistencia.AppRepositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace HospiEnCasa.App.FrontEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            //Servicio de conexión a la base de datos
            services.AddDbContext<HospiEnCasaContext>(options => options.UseSqlServer((Configuration.GetConnectionString("Database"))));
            //Agregar servicio de acciones a la base de datos
            services.AddTransient<IRepositorioPersona, RepositorioPersona>();
            services.AddTransient<IRepositorioMedico, RepositorioMedico>();
            services.AddTransient<IRepositorioPaciente, RepositorioPaciente>();
            services.AddTransient<IRepositorioFamiliar, RepositorioFamiliar>();
            services.AddTransient<IRepositorioEnfermero, RepositorioEnfermero>();
            services.AddTransient<IRepositorioSigno, RepositorioSigno>();
            services.AddTransient<IRepositorioAsignado, RepositorioAsignado>();
            services.AddTransient<IRepositorioHistorium, RepositorioHistorium>();
            services.AddTransient<IRepositorioSugerencia, RepositorioSugerencia>();
            services.AddMemoryCache();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/Error");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
