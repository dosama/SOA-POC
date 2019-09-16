using Data.DBContext;
using Data.Repositories.Courses;
using Data.Repositories.CourseStatus;
using Data.Repositories.ExamGrades;
using Data.Repositories.Exams;
using Data.Repositories.UserCourses;
using Data.Repositories.UserExams;
using Data.Repositories.UserRoles;
using Data.Repositories.Users;
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
                (options => options.UseSqlServer(connectionString));
            services.AddSingleton<IUsersRepository, UsersRepository>();
            services.AddSingleton<IUserRolesRepository, UserRolesRepository>();
            services.AddSingleton<IUserExamsRepository, UserExamsRepository>();
            services.AddSingleton<IUserCoursesRepository, UserCoursesRepository>();
            services.AddSingleton<IExamsRepository, ExamsRepository>();
            services.AddSingleton<IExamGradesRepository, ExamGradesRepository>();
            services.AddSingleton<ICourseStatusRepository, CourseStatusRepository>();
            services.AddSingleton<ICoursesRepository, CoursesRepository>();
            services.AddSingleton<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }

    }
}
