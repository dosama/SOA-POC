using System;
using Data.Repositories.Courses;
using Data.Repositories.Exams;
using Data.Repositories.Students;


namespace Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICoursesRepository Courses { get; }
        IExamsRepository Exams { get; }
        IStudentsRepository Students { get; }

        int Save();
    }
}
