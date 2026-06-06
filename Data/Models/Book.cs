namespace BookFlow___Library_Management_System.Data.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int Quantity { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<BorrowRecord> BorrowRecords { get; set; }
    }
}
