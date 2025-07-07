using FixedAssets.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetSystem.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<int> GetUserCountAsync();
        Task<int> GetActiveUserCountAsync();
        Task ActivateUserAsync(int id);
        Task<User?> GetUserByUsernameAsync(string userName); 
        Task<User?> ValidateUserAsync(string username, string password);

        
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
