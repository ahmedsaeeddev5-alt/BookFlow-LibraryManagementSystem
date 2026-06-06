using System.ComponentModel.DataAnnotations;

namespace BookFlow___Library_Management_System.Data.Dtos
{
    public class dtoNewUser
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string email { get; set; }
        public string? PhoneNumber { get; set; }


    }
}
