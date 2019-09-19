using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.Repositories.Students;
using StudentsBusiness.Models;

namespace StudentsBusiness.Service
{
    class StudentsService : IStudentsService
    {
        private readonly IStudentsRepository _students;
        private readonly IMapper _mapper;

        public StudentsService(IStudentsRepository students, IMapper mapper)
        {
            _students = students;
            _mapper = mapper;
        }

        public async Task<List<StudentDetails>> GetStudentsList()
        {
            try
            {

                List<StudentDetails> result = new List<StudentDetails>();
                var students = await _students.GetStudentsList();

                if (students != null && students.Count>0)
                {
                    foreach (var item in students)
                    {
                        var student = _mapper.Map<StudentDetails>(item);
                         result.Add(student);   
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

        public async Task<StudentDetails> GetStudentDetails(int studentId)
        {
            try
            {

               var studentDetails = await _students.GetStudentDetails(studentId);
                var result = _mapper.Map<StudentDetails>(studentDetails);
                if (studentDetails.StudentExams != null && studentDetails.StudentExams.Count > 0)
                {
                    foreach (var item in studentDetails.StudentExams)
                    {
                        result.Exams.Add(_mapper.Map<ExamModel>(item.Exam));
                    }
                }

                if (studentDetails.StudentCourses != null && studentDetails.StudentCourses.Count > 0)
                {
                    foreach (var item in studentDetails.StudentCourses)
                    {
                        result.Courses.Add(_mapper.Map<CourseModel>(item.Course));
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
