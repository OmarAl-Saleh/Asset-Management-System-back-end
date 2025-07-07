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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [Route("GetAllCategories")]
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            var mapped = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return WrappedOkObjectResultCls.Success(mapped);
        }

        [Route("GetCategoryById/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return WrappedOkObjectResultCls.Error($"Category with ID {id} not found");

            var mapped = _mapper.Map<CategoryDto>(category);
            return WrappedOkObjectResultCls.Success(mapped);
        }

        [Route("CreateCategory")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _categoryService.AddCategoryAsync(category);
            return WrappedOkObjectResultCls.Success("Category created successfully");
        }

        [Route("UpdateCategory")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _categoryService.UpdateCategoryAsync(category);
            return WrappedOkObjectResultCls.Success("Category updated successfully");
        }

        [Route("DeleteCategory/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return WrappedOkObjectResultCls.Success("Category deleted successfully");
        }
    }
}