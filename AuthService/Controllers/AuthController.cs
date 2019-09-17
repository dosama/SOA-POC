using System;
using System.Net;
using System.Threading.Tasks;
using AuthService.Messaging;
using AuthService.ViewModels;
using Auth_Business.Models;
using Auth_Business.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceBusMessaging.Interfaces;
using ServiceBusMessaging.Models;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IServiceBusTopicSender _serviceBusTopicSender;
        public AuthController(IAuthService authService, IMapper mapper, IServiceBusTopicSender serviceBusTopicSender)
        {
            _authService = authService;
            _mapper = mapper;
            _serviceBusTopicSender = serviceBusTopicSender;
        }

      
        [HttpGet("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            try
            {
                if(request == null)
                    return BadRequest();

                var result = await _authService.Login(request);
                if (result.IsAuthenticated)
                {
                    await _serviceBusTopicSender.SendMessage(new AuthenticationPayload() { ActionName = "User_Authenticated", SessionId = result.SessionId });
                }
                return Ok(result);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.InnerException);
            }
        }

    }
}
