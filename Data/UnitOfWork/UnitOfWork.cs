using Data.DBContext;
using Data.Repositories.Courses;
using Data.Repositories.Exams;
using Data.Repositories.Students;

namespace Data.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {

        private readonly SOAContext _context;

        public UnitOfWork(SOAContext context, ICoursesRepository courses, IExamsRepository exams,
      IStudentsRepository students)
        {
            _context = context;
            Courses = courses;
            Exams = exams;
            Students = students;
        }

        public ICoursesRepository Courses { get; }
        public IExamsRepository Exams { get; }
        public IStudentsRepository Students { get; }


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
