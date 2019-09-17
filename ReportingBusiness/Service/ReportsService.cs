﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.Repositories.Courses;
using Data.Repositories.Exams;
using Data.Repositories.Students;
using Data.Repositories.Users;
using ReportingBusiness.Models;

namespace ReportingBusiness.Service
{
    class ReportsService : IReportsService
    {
        private readonly IStudentsRepository _studentsRepository;
        private readonly ICoursesRepository _coursesRepository;
        private readonly IExamsRepository _examsRepository;
        private readonly IMapper _mapper;

        public ReportsService(IStudentsRepository studentsRepository,ICoursesRepository coursesRepository, IExamsRepository examsRepository, IMapper mapper)
        {
            _studentsRepository = studentsRepository;
            _coursesRepository = coursesRepository;
            _examsRepository = examsRepository;
            _mapper = mapper;
        }

        private async Task<List<ExamModel>> GetExamsData()
        {
            var examsData = new List<ExamModel>();
            var exams = await _examsRepository.GetExamsList();

            if (exams != null && exams.Count > 0)
            {
                foreach (var item in exams)
                {
                    var exam = _mapper.Map<ExamModel>(item);
                    examsData.Add(exam);
                }
            }
            return examsData;
        }

        private async Task<List<StudentDetails>> GetStudentDetailsData()
        {
            var studentsResult = new List<StudentDetails>();
            var students = await _studentsRepository.GetStudentsList();

            if (students != null && students.Count > 0)
            {
                foreach (var item in students)
                {
                    var student = _mapper.Map<StudentDetails>(item);
                    studentsResult.Add(student);
                }
            }

            return studentsResult;
        }

        private async Task<List<CourseModel>> GetCoursesData()
        {

            var coursesResult = new List<CourseModel>();
            var courses = await _coursesRepository.GetCoursesList();

            if (courses != null && courses.Count > 0)
            {
                foreach (var item in courses)
                {
                    var course = _mapper.Map<CourseModel>(item);
                    coursesResult.Add(course);
                }
            }

            return coursesResult;
        }

        public async Task<ReportModel> GenerateReport()
        {
            
            var result = new ReportModel
            {
                Exams = await GetExamsData(),
                Students = await GetStudentDetailsData(),
                Courses = await GetCoursesData()
            };

            return result;

        }

        
    }
}
