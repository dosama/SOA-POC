using AutoMapper;
using CoursesBusiness.Models;
using Data.Models;

namespace CoursesBusiness.Mapping
{
    internal class MappingProfile: Profile
    {
        public MappingProfile()
        {
            
            CreateMap<StudentDetails, Students>();
            CreateMap<Students, StudentDetails>();
            CreateMap<CourseModel, Courses>();
            CreateMap<Courses, CourseModel>();
        }
    }
}
