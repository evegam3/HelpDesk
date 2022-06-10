using Domain.models;

namespace Data.repositories
{
    public interface ICategoryRepository
    {
        public Task<Category> GetCategoryById(int categoryId);
        public Task<List<Category>> GetCategories();
        public bool CategoryExists(int categoryId);
        public Task UpdateCategory(Category Category);
        public Task<Category> AddCategory(Category Category);
        public Task RemoveCategory(Category Category);
    }
}
