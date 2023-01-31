using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<CategoryDTO>> Get()
        {
            var result = await _categoryService.GetAllCategories();
            return Ok(result);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> Get(long id)
        {
            var result = await _categoryService.GetCategoryById(id);
            return Ok(result);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult<FoodDTO>> Post([FromBody] CategoryDTO categoryDTO)
        {
            await _categoryService.AddCategory(categoryDTO);
            return Ok();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        // PUT api/<CategoryController>/5
        [HttpPut()]
        public async Task<ActionResult<CategoryDTO>> Put([FromBody] CategoryDTO categoryDTO)
        {
            await _categoryService.UpdateCategory(categoryDTO);
            return Ok();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        // DELETE api/<CategoryController>/5
        [HttpDelete()]
        public async Task<ActionResult<CategoryDTO>> Delete(long id)
        {
            await _categoryService.DeleteCategory(id);
            return Ok();
        }
    }
}
