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
        public string MyDOD { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

        public int AvailableProjectID { get; set; }
        public AvailableProjects AvailableProjects { get; set; }

        public MyDODs(string myDod, int userId, int projId)
        {
            this.MyDOD = myDod;
            this.UserID = userId;
            this.AvailableProjectID = projId;
        }
    }
}