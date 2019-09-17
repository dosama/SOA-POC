using AutoMapper;
using CoursesBusiness.Mapping;
using CoursesBusiness.Service;
using Data.Extentions;
using Microsoft.Extensions.DependencyInjection;

namespace CoursesBusiness.Extentions
{
     public static class CoursesExtention
    {

        public static void AddCoursesService(this IServiceCollection services, string dbConnectionString)
        {
           services.AddSingleton<ICoursesService, CoursesService>();
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
