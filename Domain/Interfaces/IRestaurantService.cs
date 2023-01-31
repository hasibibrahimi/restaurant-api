using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRestaurantService
    {
        Task<IEnumerable<RestaurantDTO>> GetAllRestaurants();
        Task<RestaurantDTO> GetRestaurantById(string id);
        Task AddRestaurant(RestaurantDTO restaurantDTO);
        Task UpdateRestaurant(RestaurantDTO restaurantDTO);
        Task DeleteRestaurant(string id);
    }
}
