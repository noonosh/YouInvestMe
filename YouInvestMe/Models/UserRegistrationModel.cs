using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace YouInvestMe.Models
{
    public class UserRegistrationModel
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
