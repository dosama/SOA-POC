using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServiceBusMessaging.Interfaces;
using ServiceBusMessaging.Models;
using StudentsBusiness.Service;

namespace StudentsService.Messaging
{
    internal class StudentsProcessData:IProcessData
    {
        private readonly IStudentsService _studentsService;
        private readonly IServiceBusTopicSender _serviceBusTopicSender;
        public StudentsProcessData(IStudentsService studentsService, IServiceBusTopicSender serviceBusTopicSender)
        {
            _studentsService = studentsService;
            _serviceBusTopicSender = serviceBusTopicSender;
        }

        public async Task Process(Payload payload)
        {
            if (!string.IsNullOrEmpty(payload?.ActionName))
            {
                switch (payload.ActionName)
                {
                    case "GetStudents":
                        var students = await _studentsService.GetStudentsList();
                        await _serviceBusTopicSender.SendMessage(new Payload()
                        {
                            ActionName = "GetStudents_Completed",
                            JsonContent = JsonConvert.SerializeObject(students)
                        });
                        break;
                    case "GetStudentDetails":
                        var studentsDetails = await _studentsService.GetStudentDetails(int.Parse(payload.JsonContent));
                        await _serviceBusTopicSender.SendMessage(new Payload() { ActionName = "GetStudentDetails_Completed", JsonContent = JsonConvert.SerializeObject(studentsDetails) });
                        break;
                }
            }

        }
    }
}
