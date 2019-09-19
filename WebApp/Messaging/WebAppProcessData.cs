using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using ServiceBusMessaging.Interfaces;
using ServiceBusMessaging.Models;

namespace WebApp.Messaging
{
    internal  class WebAppProcessData :IProcessData
    {
        private IHubContext<SignalRHub> _hub;

        public WebAppProcessData(IHubContext<SignalRHub> hub)
        {
            _hub = hub;
        }



        public Task Process(Payload payload)
        {
            if (!string.IsNullOrEmpty(payload?.ActionName))
            {
                switch (payload.ActionName)
                {
                    case "GetCourses_Completed":
                        _hub.Clients.All.SendAsync("GetCourses_Completed", payload);
                        break;
                    case "GetCourseDetails_Completed":
                        _hub.Clients.All.SendAsync("GetCourseDetails_Completed", payload);
                        break;
                    case "GetExams_Completed":
                        _hub.Clients.All.SendAsync("GetExams_Completed", payload);
                        break;
                    case "GetExamDetails_Completed":
                        _hub.Clients.All.SendAsync("GetExamDetails_Completed", payload);
                        break;
                    case "GenerateReport_Completed":
                        _hub.Clients.All.SendAsync("GenerateReport_Completed", payload);
                        break;
                    case "GetStudents_Completed":
                        _hub.Clients.All.SendAsync("GetStudents_Completed", payload);
                        break;
                    case "GetStudentDetails_Completed":
                        _hub.Clients.All.SendAsync("GetStudentDetails_Completed", payload);
                        break;

                }
            }
            return null;
        }
    
    }
}
