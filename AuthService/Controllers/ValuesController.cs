using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AuthService.ViewModels;
using Auth_Business.Models;
using Auth_Business.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        // POST api/values
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseModelVm>> Login([FromBody] LoginRequestModelVm request)
        {
            try
            {
                if(request == null)
                    return BadRequest();

                var model = _mapper.Map<LoginRequest>(request);
                var result = await _authService.Login(model);
                return Ok( _mapper.Map<LoginResponseModelVm>(result));

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.InnerException);
            }
        }

    }
}
