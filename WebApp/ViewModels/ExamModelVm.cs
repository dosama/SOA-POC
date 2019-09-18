using System;

namespace WebApplication2.ViewModels
{
    public class ExamModelVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int? Duration { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

    }
}
