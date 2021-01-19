
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAndAuthorizationServer.Models
{
    //[Table("Users")]
    public class ApplicationUser
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "The {0} field is mandatory.")]
        [EmailAddress(ErrorMessage = "Incorrect email address.")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string FirstName { get; set; }
        [Column(TypeName= "nvarchar(150)")]
        public string LastName { get; set; }

        public virtual ICollection<PublicChatMessage> Messages { get; set; }
    
    }
}
