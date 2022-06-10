using Data.context;
using Domain.models;
using Microsoft.EntityFrameworkCore;

namespace Data.repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly HelpDeskDbContext _context;

        public CategoryRepository(HelpDeskDbContext context) => _context = context;

        public async Task<Category> GetCategoryById(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId) ?? new Category();
            return category;
        }

        public async Task<List<Category>> GetCategories()
        {
            var categories = new List<Category>();
            if (_context != null)
            {
                categories = await _context.Categories.ToListAsync();
            }
            return categories;
        }

        public bool CategoryExists(int categoryId)
        {
            if (_context != null)
            {
                return _context.Categories.Any(e => e.CategoryId == categoryId);
            }
            return false;
        }

        public async Task UpdateCategory(Category Category)
        {
            if (_context != null)
            {
                _context.Categories.Update(Category).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Category> AddCategory(Category Category)
        {
            if (_context != null)
            {
                _context.Categories.Add(Category);
                await _context.SaveChangesAsync();
            }
            return Category;
        }

        public async Task RemoveCategory(Category Category)
        {
            if (_context != null)
            {
                _context.Categories.Remove(Category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
