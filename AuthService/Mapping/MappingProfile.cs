using AuthService.ViewModels;
using Auth_Business.Models;
using AutoMapper;

namespace AuthService.Mapping
{
    internal class MappingProfile: Profile
    {
        public MappingProfile()
        {
            
            CreateMap<LoginRequest, LoginRequestModelVm>();
            CreateMap<LoginRequestModelVm, LoginRequest>();
            CreateMap<LoginResponse, LoginResponseModelVm>();
            CreateMap<LoginResponseModelVm, LoginResponse>();
            CreateMap<UserDetails, UserDetailsVm>();
            CreateMap<UserDetailsVm, UserDetails>();
        }
    }
}
