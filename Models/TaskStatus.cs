using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Models
{
    public class TaskStatus
    {
        [Key]
        public int? TaskStatusID { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Please enter a task status name")]
        public string TaskStatuName { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Deleted { get; set; }
    }
}
