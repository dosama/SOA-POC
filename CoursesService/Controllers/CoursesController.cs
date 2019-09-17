using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using CoursesBusiness.Service;
using CoursesService.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoursesService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {

        private readonly ICoursesService _coursesService;
        private readonly IMapper _mapper;
        public CoursesController(ICoursesService coursesService, IMapper mapper)
        {
            _coursesService = coursesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseModelVm>>> Get()
        {
            try
            {
                var result = new List<CourseModelVm>();
                var courses = await _coursesService.GetCoursesList();
                if (courses != null && courses.Count > 0)
                {
                    foreach (var item in courses)
                    {
                        var course = _mapper.Map<CourseModelVm>(item);
                        result.Add(course);
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
        public async Task<ActionResult<CourseDetailsModelVm>> Get(int id)
        {
            try
            {

                var result = new CourseDetailsModelVm();
                var course = await _coursesService.GetCourseDetails(id);

                 result.CourseDetails = _mapper.Map<CourseModelVm>(course.CourseDetails);
                if (course.CourseStudents != null && course.CourseStudents.Count > 0)
                {
                    foreach (var item in course.CourseStudents)
                    {
                        var student = _mapper.Map<StudentDetailsVm>(item);
                        result.CourseStudents.Add(student);
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
    }
}
