using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DOD_Maker_Hamza.Models
{
    public class DOD_Option
    {
        [Key]
        public int DODOptionID { get; set; }

        public string Option_Text { get; set; }

      //  [ForeignKey("DODTemplates")]
        public int DODTemplateID { get; set; }

        //[ForeignKey("DODTemplateID")]
        public virtual DODTemplates DODTemplates { get; set; }

        //  [ForeignKey("DOD_Type")]
        public int Type_ID { get; set; }

        //   [ForeignKey("Type_ID")]
        public virtual DOD_Type DOD_Type { get; set; }

    }
}