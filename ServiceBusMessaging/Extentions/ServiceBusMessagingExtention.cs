﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceBusMessaging.Interfaces;

namespace ServiceBusMessaging.Extentions
{
     public static class ServiceBusMessaging
    {

        public static void AddServiceBusMessaging(this IServiceCollection services)
        {
            services.AddSingleton<IServiceBusTopicSender, ServiceBusTopicSender>();
            services.AddSingleton<IServiceBusTopicSubscriber, ServiceBusTopicSubscriber>();
          
        }

        public static void UseServiceBusMessagingRegisery(this IApplicationBuilder app)
        {
            var busSubscription =
                app.ApplicationServices.GetService<IServiceBusTopicSubscriber>();
            busSubscription.RegisterOnMessageHandlerAndReceiveMessages();

        }

    }
}
