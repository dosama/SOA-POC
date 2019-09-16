using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceBusMessaging.Interfaces;
using ServiceBusMessaging.Models;
using StudentsBusiness.Service;
using StudentsService.ViewModels;

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
        public async Task<ActionResult<List<StudentDetailsVm>>> Get()
        {
            try
            {
                var result = new List<StudentDetailsVm>();
                var students = await _studentsService.GetStudentsList();
                if (students != null && students.Count > 0)
                {
                    foreach (var item in students)
                    {
                        var student = _mapper.Map<StudentDetailsVm>(item);
                        result.Add(student);
                    }
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.InnerException);
            }
        }

        [HttpGet("{id}")]
        public  async Task<ActionResult<StudentDetailsVm>> Get(int id)
        {
            try
            {
                var student = await _studentsService.GetStudentDetails(id);
               
                var result = _mapper.Map<StudentDetailsVm>(student);
                
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
