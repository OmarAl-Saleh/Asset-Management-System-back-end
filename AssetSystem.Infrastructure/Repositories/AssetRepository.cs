using FixedAssets.Domain.Entities;
using FixedAssets.Domain.Interfaces;
using FixedAssets.Domain.Interfaces.Repositories;
using FixedAssets.Infrastructure;
using Microsoft.EntityFrameworkCore;

public class AssetRepository : IAssetRepository
{
    private readonly FixedAssetsDbContext _context;

    public AssetRepository(FixedAssetsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Asset>> GetAllAsync()
    {
        return await _context.Assets
            .Include(a => a.Category)
            .Include(a => a.Location)
            .ToListAsync();
    }

    public async Task<Asset?> GetByIdAsync(int id)
    {
        return await _context.Assets
            .Include(a => a.Category)
            .Include(a => a.Location)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<int> GetCountAsync()
    {
        return await _context.Assets.CountAsync();
    }

    public async Task AddAsync(Asset asset)
    {
        await _context.Assets.AddAsync(asset);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Asset asset)
    {
        _context.Assets.Update(asset);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _context.Assets
            .Where(a => a.Id == id)
            .ExecuteDeleteAsync();
        await _context.SaveChangesAsync();
    }
}
