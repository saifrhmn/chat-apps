using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAndAuthorizationServer.Models
{
    public class ApplicationUserModel
    {
        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "The {0} field is mandatory.")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        [Required(ErrorMessage = "The {0} field is mandatory.")]
        public string LastName { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "The {0} field is mandatory.")]
        [EmailAddress(ErrorMessage = "Incorrect email address.")]
        public string Email { get; set; }
        
       
    }
}
