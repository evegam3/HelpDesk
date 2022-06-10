using Domain.models.dto;

namespace Data.services
{
    public interface ICategoryService
    {
        public Task<CategoryDto> GetCategoryById(int categoryId);
        public Task<List<CategoryDto>> GetCategories();
        public bool CategoryExists(int categoryId);
        public Task UpdateCategory(CategoryDto categoryDto);
        public Task AddCategory(CategoryDto categoryDto);
        public Task RemoveCategory(CategoryDto CategoryDto);
    }
}
