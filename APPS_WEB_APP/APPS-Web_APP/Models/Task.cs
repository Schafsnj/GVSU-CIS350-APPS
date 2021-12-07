using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APPS_Web_APP.Models
{
    public class Task
    {
        public int Id { get; set; }
        

        [Required]
        [StringLength(40, MinimumLength = 4)]

        [DisplayName("Task Name")]
        public string TaskName { get; set; }

        [Required]
        [DisplayName("Task Description")]
        public string TaskDesc { get; set; }

        [Required]
        [DisplayName("Company")]
        public string Company { get; set; }

        [Required]
        [DisplayName("Contact")]
        [DataType(DataType.PhoneNumber)]
        public string Contact { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Status { get; set; }
    }
}
