using Data.DBContext;
using Data.Repositories.Courses;
using Data.Repositories.CourseStatus;
using Data.Repositories.ExamGrades;
using Data.Repositories.Exams;
using Data.Repositories.UserCourses;
using Data.Repositories.UserExams;
using Data.Repositories.UserRoles;
using Data.Repositories.Users;

namespace Data.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {

        private readonly SOAContext _context;

        public UnitOfWork(SOAContext context, ICoursesRepository courses, IExamsRepository exams, IUsersRepository users, 
            ICourseStatusRepository courseStatus, IExamGradesRepository examGrades,
            IUserCoursesRepository userCourses, IUserExamsRepository userExams, IUserRolesRepository userRoles)
        {
            _context = context;
            Courses = courses;
            Exams = exams;
            Users = users;
            CourseStatus = courseStatus;
            ExamGrades = examGrades;
            UserCourses = userCourses;
            UserExams = userExams;
            UserRoles = userRoles;
        }

        public ICoursesRepository Courses { get; }
        public IExamsRepository Exams { get; }
        public IUsersRepository Users { get; }
        public ICourseStatusRepository CourseStatus { get; }
        public IExamGradesRepository ExamGrades { get; }
        public IUserCoursesRepository UserCourses { get; }
        public IUserExamsRepository UserExams { get; }
        public IUserRolesRepository UserRoles { get; }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
