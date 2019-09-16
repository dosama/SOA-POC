using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.Repositories.Students;
using Data.Repositories.Users;
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
                return _mapper.Map<StudentDetails>(studentDetails);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
