using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FixedAssets.Domain.Entities;
using FixedAssets.Domain.Interfaces.Services;
using FixedAssets.Domain.Interfaces.Repositories;




namespace FixedAssets.Application.Services
{
    public class AssetsService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;

        public AssetsService(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public Task AddAssetAsync(Asset Asset) => _assetRepository.AddAsync(Asset);
        

        public Task DeleteAssetAsync(int id) => _assetRepository.DeleteAsync(id);

        public Task<int> GetAssetCountAsync() => _assetRepository.GetCountAsync();
        

        public Task<IEnumerable<Asset>> GetAllAssetsAsync() => _assetRepository.GetAllAsync();
        

        public Task<Asset?> GetAssetByIdAsync(int id) => _assetRepository.GetByIdAsync(id);
        

        public Task UpdateAssetAsync(Asset Asset) => _assetRepository.UpdateAsync(Asset);
        
    }
}
