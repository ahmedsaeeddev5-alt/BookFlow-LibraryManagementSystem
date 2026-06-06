namespace BookFlow___Library_Management_System.Data.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<BookDto> Books { get; set; }
    }
}

