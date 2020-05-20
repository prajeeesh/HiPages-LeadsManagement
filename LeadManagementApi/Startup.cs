using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeadManagementApi.Models;
using LeadManagementApi.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MediatR;
using LeadManagementApi.Repository;

namespace LeadManagementApi
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
            var server = Configuration["DBServer"] ?? "localhost";
            var port = Configuration["DBPort"] ?? "1433";
            var user = Configuration["DBUser"] ?? "LeadsManager";
            var password = Configuration["DBPassword"] ?? "M@nag3Leads";
            var database = Configuration["Database"] ?? "LeadsDB";

            //services.AddDbContext<LeadsDBContext>(options =>
            //    options.UseSqlServer($"Server={server},{port}; Initial Catalog ={database}; User ID={user}; Password={password}")
            // );
            services.AddDbContext<LeadsDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

            services.AddMediatR(typeof(Startup));

            services.AddTransient<ILeadsRepository, LeadsRepository>();

            services.AddSingleton(Configuration);
            services.Add(new ServiceDescriptor(typeof(ILeadsUtils), new LeadsUtils(Configuration)));
            //services.Add(new ServiceDescriptor(typeof(ILeadsUtils), new LeadsUtils(Configuration)));

            //To enable the CORS so that the React application can access the APIs
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors(options =>
                options.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            PrepopulateDB.PerpopulateTables(app);

            
        }
    }
}
