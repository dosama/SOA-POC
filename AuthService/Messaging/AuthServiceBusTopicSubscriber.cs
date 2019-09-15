﻿using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AuthService.Messaging.Interfaces;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AuthService.Messaging
{
    internal class AuthServiceBusTopicSubscriber : IServiceBusTopicSubscriber
    {

        private readonly IConfiguration _configuration;
        private readonly SubscriptionClient _subscriptionClient;
        private const string TOPIC_PATH = "mytopic";
        private const string SUBSCRIPTION_NAME = "mytopicsubscription";
        private readonly ILogger _logger;
        private readonly  IProcessData _processData;
        public AuthServiceBusTopicSubscriber(IProcessData processData,
            IConfiguration configuration,
            ILogger<AuthServiceBusTopicSubscriber> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _processData = processData;
            _subscriptionClient = new SubscriptionClient(
                _configuration.GetConnectionString("ServiceBusConnectionString"),
                TOPIC_PATH,
                SUBSCRIPTION_NAME);
        }

        public void RegisterOnMessageHandlerAndReceiveMessages()
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            _subscriptionClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        private async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            var myPayload = JsonConvert.DeserializeObject<object>(Encoding.UTF8.GetString(message.Body));
             _processData.Process(myPayload);
            await _subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            _logger.LogError(exceptionReceivedEventArgs.Exception, "Message handler encountered an exception");
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;

            _logger.LogDebug($"- Endpoint: {context.Endpoint}");
            _logger.LogDebug($"- Entity Path: {context.EntityPath}");
            _logger.LogDebug($"- Executing Action: {context.Action}");

            return Task.CompletedTask;
        }

        public async Task CloseSubscriptionClientAsync()
        {
            await _subscriptionClient.CloseAsync();
        }
    }
}
