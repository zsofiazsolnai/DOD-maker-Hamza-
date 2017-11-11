using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOD_Maker_Hamza.Models
{
    public class DODTemplates
    {
        [Key]
        public int DODTemplateID { get; set; }

        public string DODTemplate { get; set; }

        public DODTemplates()
        {

        }
    }
}