using AutoMapper;
using Data.repositories;
using Domain.models;
using Domain.models.dto;

namespace Data.services
{
    public class CategoryService : ICategoryService
    {
		private readonly ICategoryRepository _categoryRepository;
		private readonly IMapper _autoMapper;

		public CategoryService(ICategoryRepository categoryRepository, IMapper autoMapper)
		{
			_categoryRepository = categoryRepository;
			_autoMapper = autoMapper;
		}

        public async Task<CategoryDto> GetCategoryById(int categoryId)
        {
            return _autoMapper.Map<CategoryDto>(await _categoryRepository.GetCategoryById(categoryId));
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            return _autoMapper.Map<List<CategoryDto>>(await _categoryRepository.GetCategories());
        }

        public bool CategoryExists(int categoryId)
        {
            return _categoryRepository.CategoryExists(categoryId);
        }

        public async Task UpdateCategory(CategoryDto categoryDto)
        {
            var category = await _categoryRepository.GetCategoryById(categoryDto.CategoryId);

            if (category != null)
            {
                _autoMapper.Map(categoryDto, category);
                await _categoryRepository.UpdateCategory(category);
            }
        }

        public async Task AddCategory(CategoryDto categoryDto)
        {
            if (categoryDto != null)
            {
                var category = new Category()
                {
                    CategoryId = categoryDto.CategoryId,
                    Description = categoryDto.Description,
                    Name = categoryDto.Name,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                await _categoryRepository.AddCategory(category);
            }
        }

        public async Task RemoveCategory(CategoryDto CategoryDto)
        {
            var category = await _categoryRepository.GetCategoryById(CategoryDto.CategoryId);
            if (category != null)
            {
                _autoMapper.Map(CategoryDto, category);
                await _categoryRepository.RemoveCategory(_autoMapper.Map<Category>(category));
            }
        }
    }
}
