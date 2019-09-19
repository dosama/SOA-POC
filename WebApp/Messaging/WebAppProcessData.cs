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
                        _hub.Clients.All.SendAsync("transferchartdata", payload);
                        break;
                    case "GetCourseDetails_Completed":
                        _hub.Clients.All.SendAsync("transferchartdata", payload);
                        break;
                    case "GetExams_Completed":
                        _hub.Clients.All.SendAsync("transferchartdata", payload);
                        break;
                    case "GetExamDetails_Completed":
                        _hub.Clients.All.SendAsync("transferchartdata", payload);
                        break;
                    case "GenerateReport_Completed":
                        _hub.Clients.All.SendAsync("transferchartdata", payload);
                        break;
                    case "GetStudents_Completed":
                        _hub.Clients.All.SendAsync("transferchartdata", payload);
                        break;
                    case "GetStudentDetails_Completed":
                        _hub.Clients.All.SendAsync("transferchartdata", payload);
                        break;

                }
            }
            return null;
        }
    
    }
}
