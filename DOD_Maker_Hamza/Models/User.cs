using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DOD_Maker_Hamza.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }         // number of the question

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }    // text of question

        [Required(ErrorMessage = "Email ID is required")]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }          // correct Answer of the specific question

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }          // correct Answer of the specific question

        [Compare("Password",ErrorMessage = "Please Confirm your password")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        // Constructor of this class with all of its properties
        public User(string fName, string lName, string email, string pword, string cpword)
        {
            FirstName = fName;
            LastName = lName;
            EmailID = email;
            Password = pword;
            ConfirmPassword = cpword;
        }

        //Default constructor
        public User()
        {

        }

        public virtual List<MyDODs> MyDods { get; set; }
    }
}