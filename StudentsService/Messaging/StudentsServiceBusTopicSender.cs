using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messaging.Interfaces;
using Messaging.Models;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace StudentsAPI.Messaging
{
    internal class StudentsServiceBusTopicSender:IServiceBusTopicSender
    {
        private readonly TopicClient _topicClient;
        private const string TopicPath = "poc-topic";
        private readonly ILogger _logger;

        public StudentsServiceBusTopicSender(IConfiguration configuration,
            ILogger<StudentsServiceBusTopicSender> logger)
        {
            _logger = logger;
            _topicClient = new TopicClient(
                configuration.GetConnectionString("ServiceBusConnectionString"),
                TopicPath
            );
        }

        public async Task SendMessage(PayloadBase payload)
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
