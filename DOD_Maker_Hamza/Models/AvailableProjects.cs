using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOD_Maker_Hamza.Models
{
    public class AvailableProjects
    {
        [Key]
        public int AvailableProjectID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string AvailableProjectName { get; set; }

        public virtual List<MyDODs> MyDods { get; set; }
    }
}