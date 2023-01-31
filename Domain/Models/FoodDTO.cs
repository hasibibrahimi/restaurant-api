using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class FoodDTO
    {
        public long Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string? RestaurantId { get; set; }
        public long? CategoryId { get; set; }
        public CategoryDTO? Category { get; set; }
    }
}
