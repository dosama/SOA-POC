using Messaging.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentsAPI.Messaging;

namespace StudentsAPI
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

            var connection = Configuration.GetConnectionString("ServiceBusConnectionString");

//            services.AddDbContext<BloggingContext>
//                (options => options.UseSqlServer(connection));

            services.AddSingleton<IServiceBusTopicSender, StudentsServiceBusTopicSender>();
            services.AddSingleton<IServiceBusTopicSubscriber, StudentsServiceBusTopicSubscriber>();
            services.AddTransient<IProcessData, StudentProcessData>();
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
            var busSubscription =
                app.ApplicationServices.GetService<IServiceBusTopicSubscriber>();
            busSubscription.RegisterOnMessageHandlerAndReceiveMessages();

          

        }
    }
}
