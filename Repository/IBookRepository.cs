using BookFlow___Library_Management_System.Data.Models;

namespace BookFlow___Library_Management_System.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();

        Task<Book> GetByIdAsync(int id);

        Task<IEnumerable<Book>> SearchByTitleAsync(string title);

        Task AddAsync(Book book);

        void Update(Book book);

        void Delete(Book book);

        Task SaveChangesAsync();
    }
}
