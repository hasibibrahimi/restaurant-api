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
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;
        public FoodService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<IEnumerable<FoodDTO>> GetAllFoods()
        {
            var foods =  await _foodRepository.GetAllFoods();
            return foods.Select(x => new FoodDTO
            {
                Id = x.Id,
                Image = x.Image,
                Name = x.Name,
                Price = x.Price,
                RestaurantId = x.RestaurantId,
                CategoryId = x.CategoryId
            }).ToList();
        }

        public async Task<FoodDTO> GetFoodById(long id)
        {
            var food = await _foodRepository.GetFoodById(id);
            if (food == null)
            {
                return null;
            }
            return new FoodDTO
            {
                Id = food.Id,
                Image = food.Image,
                Name = food.Name,
                Price = food.Price,
                RestaurantId = food.RestaurantId,
                CategoryId = food.CategoryId
            };
        }
        public async Task AddFood(FoodDTO foodDTO)
        {
            var food = new Food
            {
                Id = foodDTO.Id,
                Image = foodDTO.Image,
                Name = foodDTO.Name,
                Price = foodDTO.Price,
                RestaurantId = foodDTO.RestaurantId,
                CategoryId = foodDTO.CategoryId
            };
             await _foodRepository.AddFood(food);
        }

        public async Task UpdateFood(FoodDTO foodDTO)
        {
            var food = await _foodRepository.GetFoodById(foodDTO.Id);
            food.Image = foodDTO.Image;
            food.Name = foodDTO.Name;
            food.Price = foodDTO.Price;
            food.RestaurantId = foodDTO.RestaurantId;
            food.CategoryId = foodDTO.CategoryId;
            await _foodRepository.UpdateFood(food);
        }

        public async Task DeleteFood(long id)
        {
           await _foodRepository.DeleteFood(id);
        }
    }
}
