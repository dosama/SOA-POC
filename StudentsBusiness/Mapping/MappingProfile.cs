using AutoMapper;
using Data.Models;
using StudentsBusiness.Models;

namespace StudentsBusiness.Mapping
{
    internal class MappingProfile: Profile
    {
        public MappingProfile()
        {
            
            CreateMap<StudentDetails, Students>();
            CreateMap<Students, StudentDetails>();
            CreateMap<ExamModel, Exams>();
            CreateMap<Exams, ExamModel>();
            CreateMap<CourseModel, Courses>();
            CreateMap<Courses, CourseModel>();
        }
    }
}
