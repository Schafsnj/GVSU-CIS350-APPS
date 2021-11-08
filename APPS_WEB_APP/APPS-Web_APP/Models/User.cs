using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace APPS_Web_APP.Models
{
    public class User
    {
        
        public int Id { get; set; }

        [DisplayName("Username")]
        public string UserName { get; set; }
        public string Password { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
