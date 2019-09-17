using AutoMapper;
using Data.Models;
using ReportingBusiness.Models;

namespace ReportingBusiness.Mapping
{
    internal class MappingProfile: Profile
    {
        public MappingProfile()
        {
            
            CreateMap<StudentDetails, Users>();
            CreateMap<Users, StudentDetails>();
            CreateMap<CourseModel, Courses>();
            CreateMap<Courses, CourseModel>();
            CreateMap<ExamModel, Exams>();
            CreateMap<Exams, ExamModel>();
        }
    }
}
