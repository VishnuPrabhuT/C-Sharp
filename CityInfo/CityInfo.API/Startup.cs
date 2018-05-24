using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Formatters;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using CityInfo.API.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace CityInfo.API
{
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(
                    o => o.OutputFormatters.Add(
                        new XmlDataContractSerializerOutputFormatter()));
            string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CityInfoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            services.AddDbContext<CityInfoContext>(o => o.UseSqlServer(connectionString));
            services.AddTransient<LocalMailService>();
            services.AddScoped<ICityInfoRepository, CityInfoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger, CityInfoContext cxt)
        {
            logger.AddDebug();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();

            app.UseMvc();
            cxt.EnsureSeedDataForContext();
            //app.Run((context) =>
            //{
            //    throw new Exception("Got Exception!");
            //}
            //);

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
