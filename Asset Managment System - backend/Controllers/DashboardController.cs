using AssetSystem.Application.DTOs;
using AssetSystem.Application.Services;
using AssetSystem.Common.Responses;
using AssetSystem.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asset_Managment_System___backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetDashboardStatics()
        {
            
            var dashboardEntity = await _dashboardService.GetDashboardDataAsync();

            
            var dashboardDto = new DashboardDto
            {
                TotalUsers = dashboardEntity.TotalUsers,
                TotalActiveUsers = dashboardEntity.TotalActiveUsers,
                TotalAssets = dashboardEntity.TotalAssets,
                TotalCategories = dashboardEntity.TotalCategories,
                TotalLocations = dashboardEntity.TotalLocations
            };

            return WrappedOkObjectResultCls.Success(dashboardDto);
        }
    }
}
