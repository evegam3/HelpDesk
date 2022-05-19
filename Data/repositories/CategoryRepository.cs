using Data.context;
using Domain.models;


namespace Data.repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly HelpDeskDbContext _context;

        public CategoryRepository(HelpDeskDbContext context) => _context = context;

        public Category GetCategoryById(int categoryId)
        {
            var category = _context.Categories.Find(categoryId) ?? new Category();
            return category;
        }
    }
}
