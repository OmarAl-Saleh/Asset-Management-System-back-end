using AssetSystem.Domain.Interfaces.Repositories;
using FixedAssets.Domain.Entities;
using FixedAssets.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetSystem.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly FixedAssetsDbContext _context;

        public LocationRepository(FixedAssetsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            return await _context.Locations
                .Include(l => l.Assets)
                .ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Locations.CountAsync();
        }

        public async Task<Location?> GetByIdAsync(int id)
        {
            return await _context.Locations
                .Include(l => l.Assets)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task AddAsync(Location location)
        {
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Location location)
        {
            _context.Locations.Update(location);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Locations
                .Where(l => l.Id == id)
                .ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }
    }
}
