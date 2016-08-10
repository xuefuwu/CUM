using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBP
{
    public class Menu : IKeyID
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string ImageUrl { get; set; }

        [StringLength(200)]
        public string NavigateUrl { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        [Required]
        public int SortIndex { get; set; }

       
        public virtual Menu Parent { get; set; }
        public virtual ICollection<Menu> Children { get; set; }



        public virtual Power ViewPower {get; set;}


    }
}