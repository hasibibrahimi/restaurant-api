using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllRestaurants();
        Task<ApplicationUser> GetRestaurantById(string id);
        Task AddRestaurant(ApplicationUser restaurant);
        Task UpdateRestaurant(ApplicationUser restaurant);
        Task DeleteRestaurant(string id);
    }
}
