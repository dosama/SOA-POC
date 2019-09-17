using AutoMapper;
using CoursesBusiness.Models;
using CoursesService.ViewModels;

namespace CoursesService.Mapping
{
    internal class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentDetails, StudentDetailsVm>();
            CreateMap<StudentDetailsVm, StudentDetails>();

            CreateMap<CourseModel, CourseModelVm>();
            CreateMap<CourseModelVm, CourseModel>();
            

            
        }
    }
}
