using AssetSystem.Application.DTOs;
using AssetSystem.Common.Responses;
using AssetSystem.Domain.Interfaces.Services;
using AutoMapper;
using FixedAssets.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asset_Managment_System___backend.Controllers
{
    
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [Route("GetAllUsers")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            var mapped = _mapper.Map<IEnumerable<UserDto>>(users);
            return WrappedOkObjectResultCls.Success(mapped);
        }
        
        [Route("CreateUser")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            await _userService.AddUserAsync(user);
            return WrappedOkObjectResultCls.Success("User created successfully");
        }


        [Route("ActivateUser/{id}")]
        [HttpPost]
        public async Task<IActionResult> ActivateUser(int id)
        {
            await _userService.ActivateUserAsync(id);
            return WrappedOkObjectResultCls.Success("User activated successfully");
        }

       

        [Route("DeleteUser/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return WrappedOkObjectResultCls.Success("User deleted successfully");
        }
    }
}