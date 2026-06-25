using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class ADDEmployeeDTO
    {
        [Required]
        [StringLength(50)]

        public string Firstname { get; set; }
        
        [Required] 
        [StringLength(50)]

        public string Lastname { get; set; }

        [Required]
        [EmailAddress]

        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Position { get; set; }
    }
}
