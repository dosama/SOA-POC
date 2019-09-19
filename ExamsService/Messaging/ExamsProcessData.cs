using System.Threading.Tasks;
using ExamsBusiness.Service;
using Newtonsoft.Json;
using ServiceBusMessaging.Interfaces;
using ServiceBusMessaging.Models;


namespace ExamsService.Messaging
{
    internal class ExamsProcessData:IProcessData
    {
        private readonly IExamsService _examsService;
        private readonly IServiceBusTopicSender _serviceBusTopicSender;
        public ExamsProcessData(IExamsService examsService, IServiceBusTopicSender serviceBusTopicSender)
        {
            _examsService = examsService;
            _serviceBusTopicSender = serviceBusTopicSender;
        }

        public async Task Process(Payload payload)
        {
            if (!string.IsNullOrEmpty(payload?.ActionName))
            {
                switch (payload.ActionName)
                {
                    case "GetExams":
                        var exams = await _examsService.GetExamsList();
                        await _serviceBusTopicSender.SendMessage(new Payload
                        {
                            ActionName = "GetExams_Completed",
                            JsonContent = JsonConvert.SerializeObject(exams)
                        });
                        break;
                    case "GetExamDetails":
                        
                        var examsDetails = await _examsService.GetExamDetails(int.Parse(payload.JsonContent));
                        await _serviceBusTopicSender.SendMessage(new Payload() { ActionName = "GetExamDetails_Completed", JsonContent = JsonConvert.SerializeObject(examsDetails) });
                        break;
                }
            }

        }
    }
}
