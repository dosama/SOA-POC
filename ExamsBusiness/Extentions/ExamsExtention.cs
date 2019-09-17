using AutoMapper;
using Data.Extentions;
using ExamsBusiness.Mapping;
using ExamsBusiness.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ExamsBusiness.Extentions
{
     public static class ExamsExtention
    {

        public static void AddExamsService(this IServiceCollection services, string dbConnectionString)
        {
           services.AddSingleton<IExamsService, ExamsService>();
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
