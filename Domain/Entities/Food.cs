using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Foods")]
    public class Food
    {
        public long Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public string? RestaurantId { get; set; }
        public virtual ApplicationUser? Restaurant { get; set; }

        public long? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
