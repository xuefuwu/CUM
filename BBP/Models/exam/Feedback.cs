using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BBP
{
    public class Feedback:IKeyID
    {
        [Key]
        public int ID { get; set; }

        public virtual ExamQuestion ExamQuestion { get; set; }

        public virtual Examination Examination { get; set; }
        public string context { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? Created { get; set; }
    }
}