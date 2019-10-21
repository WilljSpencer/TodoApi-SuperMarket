﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Domain.Models;
using TodoApi.Domain.Services;
using TodoApi.Resource;
using TodoApi.Extensions;
using System.Net.Http.Formatting;

namespace TodoApi.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

       List<Category> categories = new List<Category>();

       public CategoriesController(ICategoryService categoryService)
       {
           _categoryService = categoryService;
       }


        [HttpGet]
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();
            //var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            return categories;
        }

        private async Task<IActionResult> GetAllAsyncTest()
        {
            var categories = await _categoryService.ListAsync();
            //var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<DTOs.CategoryDTO> GetByIdAsync(int id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            //var categoryResource = _mapper.Map<Category, CategoryResource>();
            return result.ObjToDto();
        }

        [HttpGet("sortName")]
        public async Task<IEnumerable<Category>> GetAllOrderAsync()
        {
            var list = await _categoryService.ListAsync();
            return list.OrderBy(a => a.Name);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.SaveAsync(category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.UpdateAsync(id, category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }
    }
}
