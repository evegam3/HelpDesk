using AutoMapper;
using Data.repositories;
using Domain.models.dto;

namespace Data.services
{
    public interface ICategoryService
    {
        CategoryDto GetCategoryById(int categoryId);
    }
}
