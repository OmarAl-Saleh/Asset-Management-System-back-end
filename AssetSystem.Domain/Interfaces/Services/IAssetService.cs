using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FixedAssets.Domain.Entities;
namespace FixedAssets.Domain.Interfaces.Services
{
    public interface IAssetService
    {
        Task<IEnumerable<Asset>> GetAllAssetsAsync();
        Task<Asset?> GetAssetByIdAsync(int id);
        Task AddAssetAsync(Asset Asset);
        Task UpdateAssetAsync(Asset Asset);

        Task<int> GetAssetCountAsync();
        Task DeleteAssetAsync(int id);
    }
}
