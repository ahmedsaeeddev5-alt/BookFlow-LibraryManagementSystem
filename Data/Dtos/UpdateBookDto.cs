using System.ComponentModel.DataAnnotations;

namespace BookFlow___Library_Management_System.Data.Dtos
{
    public class UpdateBookDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Author { get; set; }

        [Range(1, 1000)]
        public int Quantity { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
