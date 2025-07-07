using AssetSystem.Application.DTOs;
using AssetSystem.Common.Responses;
using AssetSystem.Domain.Interfaces.Services;
using AutoMapper;
using FixedAssets.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asset_Managment_System___backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        public LocationController(ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        [Route("GetAllLocations")]
        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {
            var locations = await _locationService.GetAllLocationsAsync();
            var mapped = _mapper.Map<IEnumerable<LocationDto>>(locations);
            return WrappedOkObjectResultCls.Success(mapped);
        }

        [Route("GetLocationById/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var location = await _locationService.GetLocationByIdAsync(id);
            if (location == null)
                return WrappedOkObjectResultCls.Error($"Location with ID {id} not found");

            var mapped = _mapper.Map<LocationDto>(location);
            return WrappedOkObjectResultCls.Success(mapped);
        }

        [Route("CreateLocation")]
        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationDto dto)
        {
            var location = _mapper.Map<Location>(dto);
            await _locationService.AddLocationAsync(location);
            return WrappedOkObjectResultCls.Success("Location created successfully");
        }

        [Route("UpdateLocation")]
        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto dto)
        {
            var location = _mapper.Map<Location>(dto);
            await _locationService.UpdateLocationAsync(location);
            return WrappedOkObjectResultCls.Success("Location updated successfully");
        }

        [Route("DeleteLocation/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            await _locationService.DeleteLocationAsync(id);
            return WrappedOkObjectResultCls.Success("Location deleted successfully");
        }
    }
}