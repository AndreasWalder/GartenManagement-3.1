using GartenManagement.BAL;
using GartenManagement.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GartenManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //AddSingleton() erstellt bei der ersten Anforderung eine einzelne Instanz des Dienstes und verwendet dieselbe Instanz an allen Stellen, an denen dieser Dienst benötigt wird.

            //AddScoped()
            //Im Servicebereich erhalten wir bei jeder http - Anfrage eine neue Instanz.Wenn jedoch in derselben http-Anforderung der Dienst an mehreren Stellen wie in der Ansicht und im Controller erforderlich ist, wird dieselbe Instanz für den gesamten Umfang dieser http - Anforderung bereitgestellt.Bei jeder neuen http-Anforderung wird jedoch eine neue Instanz des Dienstes abgerufen.

            //AddTransient()
            //Bei einem vorübergehenden Dienst wird jedes Mal eine neue Instanz bereitgestellt, wenn eine Dienstinstanz angefordert wird, unabhängig davon, ob sie sich im Bereich derselben http-Anforderung oder über verschiedene http-Anforderungen befindet.


            services.AddRazorPages();
            services.AddServerSideBlazor();

            var context = new GartenContext();
            services.AddSingleton(context);

            services.AddScoped<AccountServices>();
            services.AddScoped<ArticleServices>();
            services.AddScoped<CategoryServices>();
            services.AddScoped<LieferantServices>();
            services.AddScoped<LieferungServices>();

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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
