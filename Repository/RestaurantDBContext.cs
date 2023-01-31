using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RestaurantDBContext : IdentityDbContext<ApplicationUser>
    {
        public RestaurantDBContext(DbContextOptions<RestaurantDBContext> options)
             : base(options)
        {
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Food>()
        .HasOne(f => f.Restaurant)
        .WithMany(r => r.Foods)
        .HasForeignKey(f => f.RestaurantId);

            modelBuilder.Entity<Food>()
                .HasOne(f => f.Category)
                .WithMany()
                .HasForeignKey(f => f.CategoryId);
        }
    }

}
