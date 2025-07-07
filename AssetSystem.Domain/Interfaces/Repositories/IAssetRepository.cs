using FixedAssets.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedAssets.Domain.Interfaces.Repositories
{
    public interface IAssetRepository
    {
        Task<IEnumerable<Asset>> GetAllAsync();

        Task<Asset?> GetByIdAsync(int id);

        Task<int> GetCountAsync();

        Task AddAsync(Asset Asset);

        Task UpdateAsync(Asset Asset);

        Task DeleteAsync(int id);

    }
}
