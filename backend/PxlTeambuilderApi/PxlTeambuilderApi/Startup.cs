﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PxlTeambuilderApi.Bootstrap;
using PxlTeambuilderApi.Data;
using PxlTeambuilderApi.Data.Domain;

namespace PxlTeambuilderApi
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

           /* PxlTeamBuilderContext context = new PxlTeamBuilderContext();
            User user = new User
            {
                Email = "thomas@student.pxl.be",
                Name = "thomas",
                Password = "thomas",
                Role = Data.Enums.UserRole.Student
            };
            context.Users.Add(user);
            context.SaveChanges();*/

            var builder = DependencyContainer.RegisterDependencies(services);
            this.ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

        }
    }
}
