using FixedAssets.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetSystem.Domain.Interfaces.Repositories
{

    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
        Task<int> GetCountAsync();
        Task<int> GetActiveAsync();
        Task ActivateAsync(int id);
        Task<User?> GetByUsernameAsync(string userName);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
