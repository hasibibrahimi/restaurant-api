using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string WorkingHours { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
    }
}
