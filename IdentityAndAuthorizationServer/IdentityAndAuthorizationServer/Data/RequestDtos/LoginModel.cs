using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAndAuthorizationServer.Models
{
    public class LoginModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "The {0} field is mandatory.")]
        public string Email { get; set; }
        
    }
}
