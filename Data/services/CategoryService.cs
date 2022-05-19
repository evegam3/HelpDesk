using AutoMapper;
using Data.repositories;
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

        public CategoryDto GetCategoryById(int categoryId)
        {
            return _autoMapper.Map<CategoryDto>(_categoryRepository.GetCategoryById(categoryId));
        }
    }
}
