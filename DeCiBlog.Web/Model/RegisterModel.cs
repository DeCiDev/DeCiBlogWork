using System.ComponentModel.DataAnnotations;

namespace DeCiBlog.Web.Model
{
    public class RegisterModel 
    {
        [Required]
        [Display(Name = "Benutzername")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "E-Mail Adresse")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "Das {0} muss mindestens {2} Zeichen lang sein.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Passwort")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Passwort bestätigen")]
        [Compare("Password", ErrorMessage = "Passwort und Passwortbestätigung stimmen nicht überein.")]
        
        public string ConfirmPassword { get; set; }

        public bool IsDisabled { get; set; }
        
    }

}
