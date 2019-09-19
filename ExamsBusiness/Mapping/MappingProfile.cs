using AutoMapper;
using Data.Models;
using ExamsBusiness.Models;

namespace ExamsBusiness.Mapping
{
    internal class MappingProfile: Profile
    {
        public MappingProfile()
        {
            
            CreateMap<StudentDetails, Students>();
            CreateMap<Students, StudentDetails>();
            CreateMap<ExamModel, Exams>();
            CreateMap<Exams, ExamModel>();
        }
    }
}
