using BookFlow___Library_Management_System.Data;
using BookFlow___Library_Management_System.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookFlow___Library_Management_System.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public async void Delete(Category category)
        {
            _context.Categories.Remove(category);
        }

        public async  Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories
                 .Include(x => x.Books)
                 .ToListAsync();
        }

        public async  Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories
                .Include(x => x.Books)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async  Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async void Update(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}
