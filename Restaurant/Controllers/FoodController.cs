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
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;
        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }
        // GET: api/<FoodController>
        [HttpGet]
        public async Task<ActionResult<FoodDTO>> Get()
        {
            var result = await _foodService.GetAllFoods();
            return Ok(result);
        }

        // GET api/<FoodController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodDTO>> Get(long id)
        {
            var result = await _foodService.GetFoodById(id);
            return Ok(result);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        // POST api/<FoodController>
        [HttpPost]
        public async Task<ActionResult<FoodDTO>> Post([FromBody] FoodDTO? foodDTO)
        {
             await _foodService.AddFood(foodDTO);
            return Ok();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        // PUT api/<FoodController>/5
        [HttpPut()]
        public async Task<ActionResult<FoodDTO>> Put([FromBody] FoodDTO foodDTO)
        {
            await _foodService.UpdateFood(foodDTO);
            return Ok();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        // DELETE api/<FoodController>/5
        [HttpDelete()]
        public async Task<ActionResult<FoodDTO>> Delete(long id)
        {
            await _foodService.DeleteFood(id);
            return Ok();
        }
    }
}
