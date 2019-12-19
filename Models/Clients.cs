using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Models
{
    public class Clients
    {
        [Key]
        public int? ClientID { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Please enter the name of the client.")]
        public string ClientName { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Please enter a client contact")]
        public int ClientContact { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Deleted { get; set; }
    }
}
