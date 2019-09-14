using System;
using System.Collections.Generic;
using System.Text;
using Data.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Courses
{
    class CoursesRepository : Repository<Models.Courses>, ICoursesRepository
    {
        public CoursesRepository(SOAContext context) : base(context)
        {
        }

        public SOAContext SOAContext => Context as SOAContext;
    }
}
