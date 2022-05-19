using Domain.models;

namespace Data.repositories
{
    public interface ICategoryRepository
    {
        Category GetCategoryById(int categoryId);
    }
}
