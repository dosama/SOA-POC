using System;
using System.Collections.Generic;
using System.Text;
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
    public interface IUnitOfWork : IDisposable
    {
        ICoursesRepository Courses { get; }
        IExamsRepository Exams { get; }
        IUsersRepository Users { get; }
        ICourseStatusRepository CourseStatus { get; }
        IExamGradesRepository ExamGrades { get; }
        IUserCoursesRepository UserCourses { get; }
        IUserExamsRepository UserExams { get; }
        IUserRolesRepository UserRoles { get; }
        int Save();
    }
}
