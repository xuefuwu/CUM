using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace BBP
{
    public class Examination:IKeyID
    {
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 题目集合
        /// </summary>
        public virtual ICollection<QuestionResult> QuestionResults { get; set; }

        /// <summary>
        /// 考核对象
        /// </summary>
        public virtual Examinee Examinee { get; set; }

        public virtual ExaminationTask ExaminationTask { get; set; }
    }

    public class QuestionResult : IKeyID
    {
        [Key]
        public int ID { get; set; }

        public virtual ExamQuestion Question { get; set; }

        public String QuestionAnswer { get; set; }
    }
}