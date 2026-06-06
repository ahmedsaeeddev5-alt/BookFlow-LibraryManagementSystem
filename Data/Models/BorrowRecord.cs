namespace BookFlow___Library_Management_System.Data.Models
{
    public class BorrowRecord
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }

        public DateTime BorrowDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
