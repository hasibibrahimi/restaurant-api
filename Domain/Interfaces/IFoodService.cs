using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFoodService
    {
        Task<IEnumerable<FoodDTO>> GetAllFoods();
        Task<FoodDTO> GetFoodById(long id);
        Task AddFood(FoodDTO foodDTO);
        Task UpdateFood(FoodDTO foodDTO);
        Task DeleteFood(long id);
    }
}
