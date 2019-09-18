using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReportingBusiness.Service;
using ServiceBusMessaging.Interfaces;
using ServiceBusMessaging.Models;

namespace ReportingService.Messaging
{
    internal class ReportsProcessData : IProcessData
    {
        private readonly IReportsService _reportsService;
        private readonly IServiceBusTopicSender _serviceBusTopicSender;
        public ReportsProcessData(IReportsService reportsService, IServiceBusTopicSender serviceBusTopicSender)
        {
            _reportsService = reportsService;
            _serviceBusTopicSender = serviceBusTopicSender;
        }

        public async Task Process(Payload payload)
        {
            if (!string.IsNullOrEmpty(payload?.ActionName))
            {
                switch (payload.ActionName)
                {
                    case "GenerateReport":
                        var report = await _reportsService.GenerateReport();
                        await _serviceBusTopicSender.SendMessage(new Payload()
                        {
                            ActionName = "GenerateReport_Completed",
                            JsonContent = JsonConvert.SerializeObject(report)
                        });
                        break;
                   
                }
            }

        }
    }
}
