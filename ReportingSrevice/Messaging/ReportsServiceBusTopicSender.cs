﻿using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ReportingService.Messaging.Interfaces;

namespace ReportingService.Messaging
{
    internal class ReportsServiceBusTopicSender:IServiceBusTopicSender
    {
        private readonly TopicClient _topicClient;
        private const string TopicPath = "poc-topic";
        private readonly ILogger _logger;

        public ReportsServiceBusTopicSender(IConfiguration configuration,
            ILogger<ReportsServiceBusTopicSender> logger)
        {
            _logger = logger;
            _topicClient = new TopicClient(
                configuration.GetConnectionString("ServiceBusConnectionString"),
                TopicPath
            );
        }

        public async Task SendMessage(object payload)
        {
            string data = JsonConvert.SerializeObject(payload);
            Message message = new Message(Encoding.UTF8.GetBytes(data));

            try
            {
                await _topicClient.SendAsync(message);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}
