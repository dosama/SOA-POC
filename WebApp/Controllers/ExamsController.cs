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
    public class ExamsController : ControllerBase
    {
        private readonly IServiceBusTopicSender _serviceBusTopicSender;


        public ExamsController(IServiceBusTopicSender serviceBusTopicSender)
        {
            _serviceBusTopicSender = serviceBusTopicSender;
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseModelVm>>> Get()
        {
            try
            {
                await _serviceBusTopicSender.SendMessage(new Payload() { ActionName = "GetExams" });
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.InnerException);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDetailsModelVm>> Get(int id)
        {
            try
            {

                await _serviceBusTopicSender.SendMessage(new Payload() { ActionName = "GetExamDetails", JsonContent = id.ToString() });
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
