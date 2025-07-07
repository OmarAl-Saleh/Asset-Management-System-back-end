using AssetSystem.Application.DTOs;
using AssetSystem.Domain.Entities;
using AssetSystem.Domain.Interfaces.Services;
using FixedAssets.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetSystem.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IUserService _userService;
        private readonly IAssetService _assetService;
        private readonly ICategoryService _categoryService;
        private readonly ILocationService _locationService;

        public DashboardService(
            IUserService userService,
            IAssetService assetService,
            ICategoryService categoryService,
            ILocationService locationService)
        {
            _userService = userService;
            _assetService = assetService;
            _categoryService = categoryService;
            _locationService = locationService;
        }

        public async Task<Dashboard> GetDashboardDataAsync()
        {
            int totalUsers = await _userService.GetUserCountAsync();
            int totalActiveUsers = await _userService.GetActiveUserCountAsync();
            int totalAssets = await _assetService.GetAssetCountAsync();
            int totalCategories = await _categoryService.GetCategoryCountAsync();
            int totalLocations = await _locationService.GetLocationCountAsync();

            

            return new Dashboard
            {
                TotalAssets = totalAssets,
                TotalActiveUsers = totalActiveUsers,
                TotalUsers = totalUsers,
                TotalCategories = totalCategories,
                TotalLocations = totalLocations
            };
        }
    }
}
