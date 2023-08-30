using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.ViewModels
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "User Name is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Keep me Signed in")]
        public bool RememberMe { get; set; }


    }
}
