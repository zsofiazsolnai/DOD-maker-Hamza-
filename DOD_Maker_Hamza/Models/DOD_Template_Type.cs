using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DOD_Maker_Hamza.Models
{
    public class DOD_Template_Type
    {
        [Key]
        public int DOD_Template_Type_ID { get; set; }
        //[ForeignKey("DODTemplates")]
        public int DODTemplateID { get; set; }

        //[ForeignKey("DODTemplateID")]
        public virtual DODTemplates DODTemplates { get; set; }

     
    }
}