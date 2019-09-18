using System;
using System.Threading.Tasks;
using CoursesBusiness.Service;
using Newtonsoft.Json;
using ServiceBusMessaging.Interfaces;
using ServiceBusMessaging.Models;

namespace CoursesService.Messaging
{
    internal class CoursesProcessData :IProcessData
    {
        private readonly ICoursesService _coursesService;
        private readonly IServiceBusTopicSender _serviceBusTopicSender;
        public CoursesProcessData(ICoursesService coursesService, IServiceBusTopicSender serviceBusTopicSender)
        {
            _coursesService = coursesService;
            _serviceBusTopicSender = serviceBusTopicSender;
        }

        public async Task Process(Payload payload)
        {
            if (!string.IsNullOrEmpty(payload?.ActionName))
            {
                switch (payload.ActionName)
                {
                    case "GetCourses":
                        var courses = await _coursesService.GetCoursesList();
                        await _serviceBusTopicSender.SendMessage(new Payload() { ActionName = "GetCourses_Completed", JsonContent = JsonConvert.SerializeObject(courses)
                        });
                        break;
                    case "GetCourseDetails":
                        var coursesDetails = await _coursesService.GetCourseDetails(int.Parse(payload.JsonContent));
                       await _serviceBusTopicSender.SendMessage(new Payload() { ActionName = "GetCourseDetails_Completed", JsonContent = JsonConvert.SerializeObject(coursesDetails) });
                        break;
                }
            }
          
        }
    }
}
