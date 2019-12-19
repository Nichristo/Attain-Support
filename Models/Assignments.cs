using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Models
{
    public class Assignments
    {
        [Key]
        public int AssignmentID { get; set; }
        public int Task { get; set; }
        public int Assigner { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Please enter the name of the assignee.")]
        public int Assignee { get; set; }
        public DateTime AssignmentDate { get; set; }
        public DateTime ExpectedCompletionDate { get; set; }
        public int Status { get; set; }
        public bool Deleted { get; set; }

    }
}
