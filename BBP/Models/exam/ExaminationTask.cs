using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BBP
{
    public class ExaminationTask : IKeyID
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }

        //public virtual Examination Examination { get; set; }

        public virtual ICollection<ExamQuestion> Questions { get; set; }

        public DateTime Created { get; set; }

        public DateTime DueDate { get; set; }

        public virtual User AssignTo { get; set; }

        public virtual ICollection<Examinee> Examinees { get; set; }
    }
    public class ExamQuestion : IKeyID
    {
        [Key]
        public int ID { get; set; }

        public virtual Question Question { get; set; }

        public double Score { get; set; }
    }
}