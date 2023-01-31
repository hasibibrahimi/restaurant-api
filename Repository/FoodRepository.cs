using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly RestaurantDBContext _context;

        public FoodRepository(RestaurantDBContext context)
        {
            _context = context;
        }
        public async Task<Food> GetFoodById(long id)
        {
            return await _context.Foods.Include(t => t.Category).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Food>> GetAllFoods()
        {
            return await _context.Foods.Include(t => t.Category).ToListAsync();
        }

        public async Task AddFood(Food food)
        {
            _context.Foods.Add(food);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFood(Food food)
        {
            _context.Foods.Update(food);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFood(long id)
        {
            var food = await _context.Foods.FindAsync(id);
            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();
        }
    }
}
