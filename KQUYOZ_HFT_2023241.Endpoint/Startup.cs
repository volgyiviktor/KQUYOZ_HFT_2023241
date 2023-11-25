using KQUYOZ_HFT_2023241.Logic.Classes;
using KQUYOZ_HFT_2023241.Logic.Interfaces;
using KQUYOZ_HFT_2023241.Models;
using KQUYOZ_HFT_2023241.Repository.Database;
using KQUYOZ_HFT_2023241.Repository.Interfaces;
using KQUYOZ_HFT_2023241.Repository.ModelRepositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KQUYOZ_HFT_2023241.EndPoint
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
            services.AddTransient<GameDbContext>();

            services.AddTransient<IRepository<Developer>, DeveloperRepository>();
            services.AddTransient<IRepository<Publisher>, PublisherRepository>();
            services.AddTransient<IRepository<Game>, GameRepository>();

            services.AddTransient<IDeveloperLogic, DeveloperLogic>();
            services.AddTransient<IPublisherLogic, PublisherLogic>();
            services.AddTransient<IGameLogic, GameLogic>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KQUYOZ_HFT_2023241.EndPoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KQUYOZ_HFT_2023241.EndPoint v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
