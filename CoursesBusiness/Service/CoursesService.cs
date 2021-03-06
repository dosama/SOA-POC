﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CoursesBusiness.Models;
using Data.Repositories.Courses;

namespace CoursesBusiness.Service
{
    class CoursesService : ICoursesService
    {
        private readonly ICoursesRepository _coursesRepository;
        private readonly IMapper _mapper;

        public CoursesService(ICoursesRepository coursesRepository, IMapper mapper)
        {
            _coursesRepository = coursesRepository;
            _mapper = mapper;
        }


        public async Task<List<CourseModel>> GetCoursesList()
        {
            try
            {

                List<CourseModel> result = new List<CourseModel>();
                var courses = await _coursesRepository.GetCoursesList();

                if (courses != null && courses.Count > 0)
                {
                    foreach (var item in courses)
                    {
                        var course = _mapper.Map<CourseModel>(item);
                        result.Add(course);
                    }
                }
                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<CourseDetailsModel> GetCourseDetails(int courseId)
        {
            try
            {
                var result = new CourseDetailsModel();
                var courseDetails = await _coursesRepository.GetCourseDetails(courseId);
                if (courseDetails != null)
                {
                    result.CourseDetails = _mapper.Map<CourseModel>(courseDetails);
                    if (courseDetails.StudentCourses != null && courseDetails.StudentCourses.Count > 0)
                    {
                        foreach (var item in courseDetails.StudentCourses)
                        {
                            var student = _mapper.Map<StudentDetails>(item.Student);
                            result.CourseStudents.Add(student);
                        }
                    }
                     
            
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }



    
}
}
