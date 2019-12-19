using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Models
{
    public class Tasks
    {
        [Key]
        public int? TaskID { get; set; }
        public int? ReferenceNumber { get; set; }
        public int? TaskPriority { get; set; }
        public int? TaskModule { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Please enter a description for your issue")]
        public string TaskDescription { get; set; }
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? TaskDocumentName { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public int? TaskStatus { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Deleted { get; set; }

    }
}
