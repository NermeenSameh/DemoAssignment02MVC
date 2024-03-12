using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAssignment02MVC
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();  // 1. Controller Activation
                                        // 2. Add Require  Services (ActionFilters , ModelBinding) to the DI Container 
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
                app.UseStatusCodePagesWithReExecute("/Home/Error");
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapGet("/Nermeen", async (context) =>
                {
                    await context.Response.WriteAsync("Hello Nermeen :)");
                });
                endpoints.MapGet("/BadRequest", async context =>
                {
                    context.Response.StatusCode = 400;
                    new BadRequestObjectResult("Error");
                });

                endpoints.MapControllerRoute(
               name: "Default",
              // pattern /*urlPath*/: "{controller}/{action}/{id?}",
              // defaults : new {controller = "Movies" , action = "Index"}
              pattern /*urlPath*/: "{controller=Movies}/{action=Index}/{id:int?}/{name:alpha?}"

              

               );

                ///  endpoints.MapControllerRoute(
                ///      name: "Default",
                ///      pattern /*urlPath*/: "Movies/GetMovie/{id}"
                ///
                ///      );
                ///
                ///  endpoints.MapControllerRoute(
                ///     name: "Other",
                ///     pattern /*urlPath*/: "Product/GetProduct/{id}"
                ///
                ///   );


            });
        }
    }
}
