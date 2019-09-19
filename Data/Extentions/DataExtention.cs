using Data.DBContext;
using Data.Repositories.Courses;
using Data.Repositories.Exams;
using Data.Repositories.Students;
using Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Extentions
{
     public static class DataExtention
    {

        public static void AddDataService(this IServiceCollection services, string connectionString)
        {
            
            services.AddDbContext<SOAContext>
                (options => options.UseSqlServer(connectionString),ServiceLifetime.Singleton);
     
            services.AddSingleton<IExamsRepository, ExamsRepository>();
            services.AddSingleton<ICoursesRepository, CoursesRepository>();
            services.AddSingleton<IStudentsRepository, StudentsRepository>();
            services.AddSingleton<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }

    }
}
