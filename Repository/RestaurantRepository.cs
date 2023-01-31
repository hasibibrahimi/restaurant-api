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
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantDBContext _context;

        public RestaurantRepository(RestaurantDBContext context)
        {
            _context = context;
        }
        public async Task<ApplicationUser> GetRestaurantById(string id)
        {
            return await _context.Users.Include(t => t.Foods).ThenInclude(t => t.Category).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllRestaurants()
        {
            return await _context.Users.Include(t => t.Foods).ThenInclude(t => t.Category).ToListAsync();
        }

        public async Task AddRestaurant(ApplicationUser restaurant)
        {
            _context.Users.Add(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRestaurant(ApplicationUser restaurant)
        {
            _context.Users.Update(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRestaurant(string id)
        {
            var restaurant = await _context.Users.FindAsync(id);
            _context.Users.Remove(restaurant);
            await _context.SaveChangesAsync();
        }
    }
}
