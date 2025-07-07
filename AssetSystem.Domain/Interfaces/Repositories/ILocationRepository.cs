using FixedAssets.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetSystem.Domain.Interfaces.Repositories
{
    public interface ILocationRepository
    {
        Task AddAsync(Location location);
        Task UpdateAsync(Location location);
        Task DeleteAsync(int id);
        Task<int> GetCountAsync();
        Task<Location?> GetByIdAsync(int id);
        Task<IEnumerable<Location>> GetAllAsync();
    }
}
