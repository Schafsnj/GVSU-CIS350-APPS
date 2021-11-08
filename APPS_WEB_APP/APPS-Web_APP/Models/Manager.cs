using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APPS_Web_APP.Models
{
    public class Manager
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 4)]
        public string Task { get; set; }

        [Required]
        [DisplayName("Task Description")]
        public string TaskDescription { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}
