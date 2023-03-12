using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Логін")]
        public string UserName { get; set; }

        [Required]
        [UIHint("password")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запам'ятати мене?")]
        public bool RememberMe { get; set; }
    }
}
