using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFoodRepository
    {
        Task<IEnumerable<Food>> GetAllFoods();
        Task<Food> GetFoodById(long id);
        Task AddFood(Food food);
        Task UpdateFood(Food food);
        Task DeleteFood(long id);
    }
}
