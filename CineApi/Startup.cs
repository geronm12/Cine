using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine.Mailer;
using IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using static IoC.Inyeccion;
 

namespace CineApi
{

    public class Startup
    {
        private readonly string _myPolicy = "_myPolicy";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            }
        );

            services.AddCors(options =>
            {
                options.AddPolicy(_myPolicy, builder => builder.WithOrigins("*").WithMethods("*").WithHeaders("*"));
            });

            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
                .AddMvcOptions(options => options.EnableEndpointRouting = false);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cine", Version = "v1" });

            });


            ConfigurationServices(services, Configuration);
             
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(_myPolicy);

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller-home}/{action=Index}/{Id}");
                //routes.MapRoute(name: "default", template: "{controller-home}/{action=Index}/{nombreUsuario,password}");
            });

            app.UseMvc();

            app.UseSwagger();



            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Cine");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });

        }

       
 
    }
}
