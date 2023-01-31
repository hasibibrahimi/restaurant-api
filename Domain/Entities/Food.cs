using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Food
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public string RestaurantId { get; set; }
        public virtual ApplicationUser Restaurant { get; set; }

        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
