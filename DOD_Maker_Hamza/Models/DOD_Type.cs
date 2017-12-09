using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DOD_Maker_Hamza.Models
{
    public class DOD_Type
    {
        [Key]
        public int Type_ID { get; set; }
        public string Type { get; set; }
    }
}