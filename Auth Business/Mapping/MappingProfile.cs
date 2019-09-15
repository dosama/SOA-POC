using Auth_Business.Models;
using AutoMapper;
using Data.Models;

namespace Auth_Business.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<UserDetails, Users>();
            CreateMap<Users, UserDetails>();
        }
    }
}
