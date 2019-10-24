using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Domain.Models;
using TodoApi.Domain.Services;
using TodoApi.Resource;
using TodoApi.Extensions;
using System.Net.Http.Formatting;
using TodoApi.Domain.Repositories;
using TodoApi.DTOs;

namespace TodoApi.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

       List<Category> filterList = new List<Category>();


        [HttpGet]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync()
        {
            var categories = await _categoryRepo.ListAsync();
            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            return resources;
        }

        [HttpGet("test")]
        public async Task<IActionResult> GetAllAsyncTest()
        {
            var categories = await _categoryRepo.ListAsync();

            if (!categories.Any())
                return this.NotFound(categories);

            return Ok(categories);
        }
        
        [HttpGet("{id}")]
        public async Task<DTOs.CategoryDTO> GetByIdAsync(int id)
        {
            var result = await _categoryRepo.FindByIdAsync(id);
            //var categoryResource = _mapper.Map<Category, CategoryResource>();
            return result.ObjToDto();
        }
       
        [HttpGet("findName")]
        public async Task<IEnumerable<Category>> GetByStringAsync(string search)
        {
            var list = await _categoryRepo.ListAsync();
            if (!String.IsNullOrEmpty(search))
            {
                list = list.Where(s => s.Name.Contains(search));
            }

            return list;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            await _categoryRepo.AddAsync(category);


            //var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            await _categoryRepo.Update(category);


            //var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok();
        }
    }
}
