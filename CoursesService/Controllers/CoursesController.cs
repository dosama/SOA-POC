using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CoursesBusiness.Models;
using CoursesBusiness.Service;
using Microsoft.AspNetCore.Mvc;

namespace CoursesService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {

        private readonly ICoursesService _coursesService;
        public CoursesController(ICoursesService coursesService)
        {
            _coursesService = coursesService;
           
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseModel>>> Get()
        {
            try
            {
                var courses = await _coursesService.GetCoursesList();
               
                return Ok(courses);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.InnerException);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDetailsModel>> Get(int id)
        {
            try
            {
                
                var course = await _coursesService.GetCourseDetails(id);

                return Ok(course);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.InnerException);
            }
        }
    }
}
