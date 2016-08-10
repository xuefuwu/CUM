using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BBP.Models
{
    public class Store:IKeyID
    {
        [Key]
        public int ID { get; set; }

        public string StoreLevel { get; set; }

        public int StoreNum { get; set; }

        public Boolean isStore { get; set; }
    }
}