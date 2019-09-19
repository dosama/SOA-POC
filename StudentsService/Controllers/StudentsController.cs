using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentsBusiness.Models;
using StudentsBusiness.Service;

namespace StudentsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService _studentsService;
        private readonly IMapper _mapper;
        public StudentsController(IStudentsService studentsService, IMapper mapper)
        {
            _studentsService = studentsService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<StudentDetails>>> Get()
        {
            try
            {
               
                var result = await _studentsService.GetStudentsList();
                
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.InnerException);
            }
        }

        [HttpGet("{id}")]
        public  async Task<ActionResult<StudentDetails>> Get(int id)
        {
            try
            {
                var result = await _studentsService.GetStudentDetails(id);
           
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
