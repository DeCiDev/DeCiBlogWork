using System.ComponentModel.DataAnnotations;

namespace DeCiBlog.Web.Model
{
    public class LoginModel 
    {
        [Required]
        [Display(Name = "Benutzername")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Passwort")]
        public string Password { get; set; }

        [Display(Name = "Anmeldeinformationen speichern?")]
        public bool RememberMe { get; set; }

        
    }
}