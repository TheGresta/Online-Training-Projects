using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiddlewarePractices.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;

namespace MiddlewarePractices
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MiddlewarePractices", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MiddlewarePractices v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();    

            //app.Run()

            //app.Run(async context => Console.WriteLine("Middeleware 1."));
            //app.Run(async context => Console.WriteLine("Middeleware 2."));

            //app.Use()
            // app.Use(async (context, next) => {
            //     Console.WriteLine("Middleware 1 begiin.");
            //     await next.Invoke();
            //     Console.WriteLine("Middleware 1 end.");
            // });

            // app.Use(async (context, next) => {
            //     Console.WriteLine("Middleware 2 begiin.");
            //     await next.Invoke();
            //     Console.WriteLine("Middleware 2 end.");
            // });

            // app.Use(async (context, next) => {
            //     Console.WriteLine("Middleware 3 begiin.");
            //     await next.Invoke();
            //     Console.WriteLine("Middleware 3 end.");
            // });

            //Custom Middleware
            app.UseHello();

            app.Use(async (context, next) => {
                Console.WriteLine("Use Middleware begiin.");
                await next.Invoke();
            });

            //app.Map()
            app.Map("/example", internalApp => internalApp.Run(async context =>{
                Console.WriteLine("/example middleware triggered");
                await context.Response.WriteAsync("/example middleware triggered");
            }));

            //app.MapWhen()
            app.MapWhen(x => x.Request.Method == "GET", InternalApp =>{
                InternalApp.Run(async context => {
                    Console.WriteLine("MapWhen Middleware tetiklendi");
                    await context.Response.WriteAsync("MapWhen Middleware tetiklendi");
                });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
