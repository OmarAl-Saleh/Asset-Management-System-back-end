using AssetSystem.Domain.Interfaces.Repositories;
using AssetSystem.Domain.Interfaces.Services;
using FixedAssets.Domain.Entities;

namespace AssetSystem.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public Task AddCategoryAsync(Category category) => _repo.AddAsync(category);

        public Task DeleteCategoryAsync(int id) => _repo.DeleteAsync(id);

        public Task<int> GetCategoryCountAsync() => _repo.GetCountAsync();
        public Task<IEnumerable<Category>> GetAllCategoriesAsync() => _repo.GetAllAsync();

        public Task<Category?> GetCategoryByIdAsync(int id) => _repo.GetByIdAsync(id);

        public Task UpdateCategoryAsync(Category category) => _repo.UpdateAsync(category);
    }
}
