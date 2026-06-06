using System.ComponentModel.DataAnnotations;

namespace BookFlow___Library_Management_System.Data.Dtos
{
    public class dtoLogin
    { 
       
            [Required]
            public string userName { get; set; }
            [Required]
            public string password { get; set; }
        


    }
}
