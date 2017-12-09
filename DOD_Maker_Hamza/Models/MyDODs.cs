using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOD_Maker_Hamza.Models
{
    public class MyDODs
    {
        [Key]
        public int MyDODs_ID { get; set; }
        public string OwnerName { get; set; }
        public string MyDOD { get; set; }
    }
}