﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReportingBusiness.Extentions;
using ReportingService.Messaging;
using ServiceBusMessaging.Extentions;
using ServiceBusMessaging.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace ReportingService
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connection = Configuration["DBConnectionString"];
            
            services.AddReportsService(connection);
            
            //            var mappingConfig = new MapperConfiguration(mc =>
            //            {
            //                mc.AddProfile(new MappingProfile());
            //            });
            //
            //
            //            IMapper mapper = mappingConfig.CreateMapper();
            //            services.AddSingleton(mapper);
            //
            services.AddServiceBusMessaging();
                        services.AddTransient<IProcessData, ReportsProcessData>();
            
                        services.AddSwaggerGen(c =>
                        {
                            c.SwaggerDoc("v1", new Info { Title = "Values Api", Version = "v1" });
                        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseServiceBusMessagingRegisery();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Values Api V1");
            });
        }
    }
}