using OskarLAspNet.Models.Entities;
using OskarLAspNet.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace OskarLAspNet.Models.ViewModels
{
    public class UserRegisterVM
    {
        //Validering går bara vid knapptryckning med C#

        [Display(Name = "First Name")]
        [MinLength(2, ErrorMessage = "Your first name need to be atleast 2 characters long")]
        [Required(ErrorMessage = "Please fill in a Firstname")] //Ändrar på errormeddelande vid failad registrering
        [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "You need to fill in a valid firstname")] //Regex  First+lastname
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        [MinLength(2, ErrorMessage = "Your last name need to be atleast 2 characters long")]
        [Required(ErrorMessage = "Please fill in a Lastname")]
        [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "You need to fill in a valid lastname")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Street Name")]
        public string StreetName { get; set; } = null!;

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; } = null!;

        [Display(Name = "City")]
        public string City { get; set; } = null!;

        [Display(Name = "Mobile (Optional)")]
        public string? Mobile { get; set; }

        [Display(Name = "Company (Optional)")]
        public string? Company { get; set; }



        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please fill in an Email")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You need to fill in a valid email")] //Regex email RFC 6531
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;



        [Display(Name = "Password")]
        [Required(ErrorMessage = "You need to fill in a password")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "You need to fill in a valid password")] //Regex password 
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;



        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "You need to confirm your password")]
        [Compare(nameof(Password), ErrorMessage = "Password doesn't match, please fill in the correct password again")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;



        //IFormFile används vid filuppladdningar
        [Display(Name = "Profile Image (Optional)")]
        [DataType(DataType.Upload)]
        public IFormFile? ImageFile { get; set; }

        [Display(Name = "I have read and accept the terms and agreements")]
        [Required(ErrorMessage = "You must agree with the terms and conditions")]
        public bool TermsAndAgreement { get; set; } = false!;


        //IMPLICIT, MYCKET SMIDIGT. DRY!
        public static implicit operator AppUser(UserRegisterVM viewModel)
        {
            return new AppUser
            {
                UserName = viewModel.Email,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                PhoneNumber = viewModel.Mobile,
                CompanyName = viewModel.Company,
                Email = viewModel.Email,
            };
        }

        public static implicit operator AddressEntity(UserRegisterVM viewModel)
        {
            return new AddressEntity
            {
                StreetName = viewModel.StreetName,
                PostalCode = viewModel.PostalCode,
                City = viewModel.City,


            };
        }
    }
}
