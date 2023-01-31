using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        // GET: api/<RestaurantController>
        [HttpGet]
        public async Task<ActionResult<RestaurantDTO>> Get()
        {
            var result = await _restaurantService.GetAllRestaurants();
            return Ok(result);
        }

        // GET api/<RestaurantController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDTO>> Get(string id)
        {
            var result = await _restaurantService.GetRestaurantById(id);
            return Ok(result);
        }

        // POST api/<RestaurantController>
        [HttpPost]
        public async Task<ActionResult<RestaurantDTO>> Post([FromBody] RestaurantDTO restaurantDTO)
        {
            await _restaurantService.AddRestaurant(restaurantDTO);
            return Ok();
        }

        // POST api/<RestaurantController>
        [HttpPost("food")]
        public async Task<ActionResult<RestaurantDTO>> AddFoodToRestaurant(string restaurantId,long foodId)
        {
            await _restaurantService.AddFoodToRestaurant(restaurantId, foodId);
            return Ok();
        }

        // PUT api/<RestaurantController>/5
        [HttpPut()]
        public async Task<ActionResult<RestaurantDTO>> Put([FromBody] RestaurantDTO restaurantDTO)
        {
            await _restaurantService.UpdateRestaurant(restaurantDTO);
            return Ok();
        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete()]
        public async Task<ActionResult<RestaurantDTO>> Delete(string id)
        {
            await _restaurantService.DeleteRestaurant(id);
            return Ok();
        }
    }
}
