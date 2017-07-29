﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BillingServices.CMS.Data;
using System.Diagnostics.Tracing;
using Microsoft.Extensions.Options;
using BillingServices.CMS.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace BillingServices.CMS
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Set to return json
            services.AddMvc(options => { options.Filters.Add(new ProducesAttribute("application/json")); });
            
            // NOTE: what does AddOptions do?
            services.AddOptions();

            //ConfigurationForAutoMapper
            var config = new AutoMapper.MapperConfiguration(cfg => {cfg.AddProfile(new AutoMapperConfigurationProfile());});
            var mapper = config.CreateMapper();
            services.AddSingleton<IMapper>(mapper);

            services.Configure<DatabaseSettings>(c =>
            {
                c.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                c.Database = Configuration.GetSection("MongoConnection:Database").Value;
            });
            
            // Puts the Database Setting in Scope for db Context
            services.AddScoped(cfg =>cfg.GetService<IOptions<DatabaseSettings>>().Value);

            services.AddScoped<DBContext, DBContext>();
            services.AddScoped<IRespository, MongoRepository>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
