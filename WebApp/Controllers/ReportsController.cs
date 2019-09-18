using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceBusMessaging.Interfaces;
using ServiceBusMessaging.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IServiceBusTopicSender _serviceBusTopicSender;


        public ReportsController(IServiceBusTopicSender serviceBusTopicSender)
        {
            _serviceBusTopicSender = serviceBusTopicSender;
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseModelVm>>> Get()
        {
            try
            {
                await _serviceBusTopicSender.SendMessage(new Payload() { ActionName = "GenerateReport" });
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.InnerException);
            }
        }
    }
}
