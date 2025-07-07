using AssetSystem.Domain.Interfaces.Repositories;
using AssetSystem.Domain.Interfaces.Services;
using FixedAssets.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace AssetSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task AddUserAsync(User user)
        {
            var existingUser = await _repo.GetByUsernameAsync(user.Username);
            if (existingUser != null)
            {
                throw new InvalidOperationException("User with this username already exists.");
            }
            
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            await _repo.AddAsync(user);
        }

        public async Task ActivateUserAsync(int id) => await _repo.ActivateAsync(id);
        

        public Task<int> GetUserCountAsync() => _repo.GetCountAsync();

        public Task<int> GetActiveUserCountAsync() => _repo.GetActiveAsync();

        public Task DeleteUserAsync(int id) => _repo.DeleteAsync(id);

        public Task<IEnumerable<User>> GetAllUsersAsync() => _repo.GetAllAsync();

       

        public async Task UpdateUserAsync(User user)
        {

            if (!user.PasswordHash.StartsWith("$2a$"))
            {
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            }
            await _repo.UpdateAsync(user);
        }

        public async Task<User?> ValidateUserAsync(string username, string password)
        {
            var user = await _repo.GetByUsernameAsync(username);
            if (user == null )
                return null;

            bool isValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            return isValid ? user : null;
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _repo.GetByUsernameAsync(username);
        } 
    }
}
