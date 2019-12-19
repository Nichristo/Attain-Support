using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Models
{
    public class Modules
    {
        [Key]
        public int? ModuleId { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Please enter the module name")]
        public string ModuleName { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Please enter the module description")]
        public string ModuleDescription { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Deleted { get; set; }
    }
}
