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
using DAL;
using Logic;
using Logic.DAL_Interfaces;
using Logic.Logic_Interfaces;

namespace Eugalp
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
            services.AddControllersWithViews();
            services.AddTransient<IDbSymptoomCategorieContext, DbSymptoomCategorieContext>();
            services.AddTransient<IDbContext, DbContext>();
            services.AddTransient<IDbMaatregelCategorieContext, DbMaatregelCategorieContext>();
            services.AddTransient<IDbMaatregelContext, DbMaatregelContext>();
            services.AddTransient<IDbNiveauContext, DbNiveauContext>();
            services.AddTransient<IDbSymptoomContext, DbSymptoomContext>();
            services.AddTransient<IDbUitbraakContext, DbUitbraakContext>();
            services.AddTransient<IDbVerbindingContext, DbVerbindingContext>();
            services.AddTransient<IDbVirusContext, DbVirusContext>();
            //services.AddTransient<ISymptoom, Symptoom>();
            services.AddTransient<ISymptoomBeheer, SymptoomBeheer>();
            //services.AddTransient<ISymptoomCategorie, SymptoomCategorie>();
            //services.AddTransient<ISymptoomCategorieBeheer, SymptoomCategorieBeheer>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
