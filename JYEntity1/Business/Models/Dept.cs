using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JYManager
{
    public class Dept : IKeyID
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int SortIndex { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        
        
        public virtual Dept Parent { get; set; }
        public virtual ICollection<Dept> Children { get; set; }


        public virtual ICollection<User> Users { get; set; }


    }
}