using AutoMapper;
using Data.Extentions;
using Microsoft.Extensions.DependencyInjection;
using ReportingBusiness.Mapping;
using ReportingBusiness.Service;

namespace ReportingBusiness.Extentions
{
     public static class ReportsExtention
    {

        public static void AddReportsService(this IServiceCollection services, string dbConnectionString)
        {
           services.AddSingleton<IReportsService, ReportsService>();
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
