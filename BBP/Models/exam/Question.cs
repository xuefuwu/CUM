using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BBP
{
    public class Question:IKeyID
    {
        [Key]
        public int ID { get; set; }


        [StringLength(500)]
        public string Title { get; set; }

        public string Description { get; set; }

        public double Score { get; set; }

        public int SortBy { get; set; }
    }
}