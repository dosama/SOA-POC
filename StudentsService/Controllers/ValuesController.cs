using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StudentsService.Messaging.Interfaces;

namespace StudentsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IServiceBusTopicSender _serviceBusTopicSender;
        public ValuesController(IServiceBusTopicSender serviceBusTopicSender)
        {
            _serviceBusTopicSender = serviceBusTopicSender;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public  void Post([FromBody] string value)
        {
         _serviceBusTopicSender.SendMessage(new object());

//            // Send this to the bus for the other services
//            await _serviceBusTopicSender.SendMessage(new MyPayload
//            {
//                Goals = request.Goals,
//                Name = request.Name,
//                Delete = false
//            });

            Ok("");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
