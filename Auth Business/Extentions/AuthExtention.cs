using Auth_Business.Mapping;
using Auth_Business.Service;
using AutoMapper;
using Data.Extentions;
using Microsoft.Extensions.DependencyInjection;

namespace Auth_Business.Extentions
{
     public static class AuthExtention
    {

        public static void AddAuthService(this IServiceCollection services, string dbConnectionString)
        {
           services.AddSingleton<IAuthService, AuthService>();
           services.AddDataService(dbConnectionString);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

    }
}
