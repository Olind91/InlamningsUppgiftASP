using System.ComponentModel.DataAnnotations;

namespace OskarLAspNet.Models.ViewModels
{
    public class UserLoginVM
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please fill in an Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;



        [Display(Name = "Password")]
        [Required(ErrorMessage = "You need to fill in a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;


        [Display(Name = "Keep me logged in")]
        public bool RememberMe { get; set; } = false!;

        public string ReturnUrl { get; set; } = "/";

    }
}

