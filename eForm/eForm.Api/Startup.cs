using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eForm.Repository;
using eForm.Repository.Interface;
using eForm.Repository.Dapper;
using eForm.Model;
using Microsoft.OpenApi.Models;


namespace eForm.Api
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var configurationBuilder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath);
            configurationBuilder = configurationBuilder.AddJsonFile("appsettings.json");
            Configuration = configurationBuilder.AddEnvironmentVariables().Build();
        }

        public IConfiguration Configuration { get; set; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            services.AddTransient<IMasterDataRepository, MasterDataRepository>();
            services.AddTransient(provider => new BaseControllerConfiguration
            {
                Configuration = Configuration,
                ConnectionString = Configuration.GetValue<string>("ConnectionString")
            });

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "Eform API", Version = "v1" });
               
            });
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "eForm API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
