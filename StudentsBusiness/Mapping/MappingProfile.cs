using AutoMapper;
using Data.Models;
using StudentsBusiness.Models;

namespace StudentsBusiness.Mapping
{
    internal class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<StudentDetails, Users>();
            CreateMap<Users, StudentDetails>();
            CreateMap<ExamModel, Exams>();
            CreateMap<Exams, ExamModel>();
            CreateMap<CourseModel, Courses>();
            CreateMap<Courses, CourseModel>();
        }
    }
}
