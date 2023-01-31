using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<IEnumerable<RestaurantDTO>> GetAllRestaurants()
        {
            var restaurants = await _restaurantRepository.GetAllRestaurants();
            return restaurants.Select(x => new RestaurantDTO
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                WorkingHours = x.WorkingHours,
                Food = x.Foods.Select(x => new FoodDTO 
                {
                    Id = x.Id, 
                    Name = x.Name,
                    Image = x.Image,
                    Category = new CategoryDTO
                    {
                        Id = x.Category.Id,
                        Name = x.Category.Name
                    }
                }).ToList(),      
            }).ToList();
        }

        public async Task<RestaurantDTO> GetRestaurantById(string id)
        {
            var restaurant = await _restaurantRepository.GetRestaurantById(id);
            if (restaurant == null)
            {
                return null;
            }
            return new RestaurantDTO
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Image = restaurant.Image,
                WorkingHours = restaurant.WorkingHours
            };
        }

        public async Task AddRestaurant(RestaurantDTO restaurantDTO)
        {
            var restaurant = new ApplicationUser
            {
                Id = restaurantDTO.Id,
                Name = restaurantDTO.Name,
                Image = restaurantDTO.Image,
                WorkingHours = restaurantDTO.WorkingHours
            };
           await _restaurantRepository.AddRestaurant(restaurant);
        }

        public async Task UpdateRestaurant(RestaurantDTO restaurantDTO)
        {
            var restaurant = await _restaurantRepository.GetRestaurantById(restaurantDTO.Id);
            restaurant.Name = restaurantDTO.Name;
            restaurant.Image = restaurantDTO.Image;
            restaurant.WorkingHours = restaurantDTO.WorkingHours;
            await _restaurantRepository.UpdateRestaurant(restaurant);
        }

        public async Task DeleteRestaurant(string id)
        {
           await _restaurantRepository.DeleteRestaurant(id);
        }
    }
}
