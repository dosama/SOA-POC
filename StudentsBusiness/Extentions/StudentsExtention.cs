using AutoMapper;
using Data.Extentions;
using Microsoft.Extensions.DependencyInjection;
using StudentsBusiness.Mapping;
using StudentsBusiness.Service;

namespace StudentsBusiness.Extentions
{
     public static class StudentsExtention
    {

        public static void AddStudentsService(this IServiceCollection services, string dbConnectionString)
        {
           services.AddSingleton<IStudentsService, StudentsService>();
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
