using System.ComponentModel.DataAnnotations;

namespace DeCiBlog.Web.Model
{
    public class LocalPasswordModel 
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Aktuelles Passwort")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Das {0} muss mindestens {2} Zeichen lang sein.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Neues Passwort")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Neues Passwort bestätigen")]
        [Compare("NewPassword", ErrorMessage = "Neues Passwort und Passwortbestätigung stimmen nicht überein.")]
        public string ConfirmPassword { get; set; }
    }
}