using AssetSystem.Domain.Interfaces.Repositories;
using AssetSystem.Domain.Interfaces.Services;
using FixedAssets.Domain.Entities;


namespace AssetSystem.Application.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _repo;

        public LocationService(ILocationRepository repo)
        {
            _repo = repo;
        }

        public Task AddLocationAsync(Location location) => _repo.AddAsync(location);

        public Task DeleteLocationAsync(int id) => _repo.DeleteAsync(id);

        public Task<int> GetLocationCountAsync() => _repo.GetCountAsync();

        public Task<IEnumerable<Location>> GetAllLocationsAsync() => _repo.GetAllAsync();

        public Task<Location?> GetLocationByIdAsync(int id) => _repo.GetByIdAsync(id);

        public Task UpdateLocationAsync(Location location) => _repo.UpdateAsync(location);
    }
}
