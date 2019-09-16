using System;
using System.Collections.Generic;
using Data.Models;

namespace StudentsService.ViewModels
{
    public class StudentDetailsVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public List<Courses> Courses { get; set; }
        public List<Exams> Exams { get; set; }

    }
}
