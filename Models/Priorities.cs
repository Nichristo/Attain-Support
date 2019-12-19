using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Models
{
    public class Priorities
    {
        [Key]
        public int? PriorityId {get; set;}
        [Required]
        [StringLength(255, ErrorMessage = "Please enter a priority level")]
        public string PriorityName { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Please enter a priority description")]
        public string PriorityDescription { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Deleted { get; set; }
    }
}
