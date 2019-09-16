using AutoMapper;
using StudentsBusiness.Models;
using StudentsService.ViewModels;

namespace StudentsService.Mapping
{
    internal class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentDetails, StudentDetailsVm>();
            CreateMap<StudentDetailsVm, StudentDetails>();

            CreateMap<CourseModel, CourseModelVm>();
            CreateMap<CourseModelVm, CourseModel>();

            CreateMap<ExamModel, ExamModelVm>();
            CreateMap<ExamModelVm, ExamModel>();

            
        }
    }
}
