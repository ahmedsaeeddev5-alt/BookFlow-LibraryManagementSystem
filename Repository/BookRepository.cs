using BookFlow___Library_Management_System.Data;
using BookFlow___Library_Management_System.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookFlow___Library_Management_System.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
        }

        public async void Delete(Book book)
        {
            _context.Books.Remove(book);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books
                 .Include(x => x.Category)
                 .ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> SearchByTitleAsync(string title)
        {
            return await _context.Books
                .Where(x => x.Title.Contains(title))
                .ToListAsync();
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
        }
    }
}
