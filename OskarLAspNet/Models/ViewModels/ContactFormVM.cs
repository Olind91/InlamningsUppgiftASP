using System.ComponentModel.DataAnnotations;

namespace OskarLAspNet.Models.ViewModels
{
    public class ContactFormVM
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please fill in a name")] //Ändrar på errormeddelande vid failad registrering
        [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "You need to fill in a valid firstname")] //Regex  First+lastname
        public string Name { get; set; } = null!;


        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please fill in an Email")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You need to fill in a valid email")] //Regex email RFC 6531
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;


        [Display(Name = "Phonenumber")]
        public string? PhoneNumber { get; set; }


        [Display(Name = "Company Name")]
        public string? Company { get; set; }


        [Display(Name = "Comment")]
        [RegularExpression(@"[\x20-\x7E]*", ErrorMessage = "Invalid comment.")] //the pattern allows any printable ASCII characters from space to tilde
        [Required(ErrorMessage = "Please fill in a comment")]
        public string Comment { get; set; } = null!;




        [Display(Name = "Save my name, email in the this browser for the next time I comment.")]
        public bool SaveMyData { get; set; } = false!;
    }
}
