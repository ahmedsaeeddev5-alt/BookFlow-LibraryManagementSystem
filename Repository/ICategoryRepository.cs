using BookFlow___Library_Management_System.Data.Models;

namespace BookFlow___Library_Management_System.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category> GetByIdAsync(int id);

        Task AddAsync(Category category);

        void Update(Category category);

        void Delete(Category category);

        Task SaveChangesAsync();
    }
}
