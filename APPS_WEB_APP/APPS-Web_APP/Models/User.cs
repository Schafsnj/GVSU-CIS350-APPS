using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APPS_Web_APP.Models
{
    public class User
    {
        
        public int Id { get; set; }

        [Required]
        [StringLength(10, MinimumLength =4)]

        [DisplayName("Username")]
        public string UserName { get; set; }

        [Required]
        [StringLength(20, MinimumLength =9)]
        public string Password { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public string Role { get; set; }
    }
}
