﻿using System;
using System.Collections.Generic;

namespace ReportingBusiness.Models
{
    public class ExamModel
    {
        public ExamModel()
        {
            Students = new List<StudentDetails>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int? Duration { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public List<StudentDetails> Students { get; set; }
    }
}
