using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RestaurantDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string WorkingHours { get; set; }
        public ICollection<FoodDTO> Food { get; set; }

    }
}
