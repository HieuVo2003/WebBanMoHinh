using WebMoHinh.Models;

namespace WebMoHinh.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int caterogyId);
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int caterogyId);
    }
}
