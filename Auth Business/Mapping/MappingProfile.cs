using Auth_Business.Models;
using AutoMapper;
using Data.Models;

namespace Auth_Business.Mapping
{
    internal class MappingProfile: Profile
    {
        public MappingProfile()
        {
            
            CreateMap<UserDetails, Users>();
            CreateMap<Users, UserDetails>();
        }
    }
}
