
using AssetSystem.Application.DTOs;
using AssetSystem.Common.Responses;
using AutoMapper;
using FixedAssets.Domain.Entities;
using FixedAssets.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asset_Managment_System___backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _assetService;
        private readonly IMapper _mapper;

        public AssetController(IAssetService assetService, IMapper mapper)
        {
            _assetService = assetService;
            _mapper = mapper;
        }

        [Route("GetAllAssets")]
        [HttpGet]
        public async Task<IActionResult> GetAllAssets()
        {
            var assets = await _assetService.GetAllAssetsAsync();
            var mapped = _mapper.Map<IEnumerable<AssetDto>>(assets);
            return WrappedOkObjectResultCls.Success(mapped);
        }

        [Route("GetAssetById/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAssetById(int id)
        {
            var asset = await _assetService.GetAssetByIdAsync(id);
            if (asset == null)
                return WrappedOkObjectResultCls.Error($"Asset with ID {id} not found");

            var mapped = _mapper.Map<AssetDto>(asset);
            return WrappedOkObjectResultCls.Success(mapped);
        }

        [Route("CreateAsset")]
        [HttpPost]
        public async Task<IActionResult> CreateAsset(CreateAssetDto dto)
        {
            var asset = _mapper.Map<Asset>(dto);
            await _assetService.AddAssetAsync(asset);
            return WrappedOkObjectResultCls.Success("Asset created successfully");
        }

        [Route("UpdateAsset")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsset(UpdateAssetDto dto)
        {
            var asset = _mapper.Map<Asset>(dto);
            await _assetService.UpdateAssetAsync(asset);
            return WrappedOkObjectResultCls.Success("Asset updated successfully");
        }

        [Route("DeleteAsset/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsset(int id)
        {
            await _assetService.DeleteAssetAsync(id);
            return WrappedOkObjectResultCls.Success("Asset deleted successfully");
        }
    }
}
