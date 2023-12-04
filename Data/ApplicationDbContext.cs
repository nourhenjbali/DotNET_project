using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using mvcp.Models;

namespace mvcp.Data
{
    // This is the constructor for the ApplicationDbContext class 
    // The DbContext is a part of Entity Framework Core, and it represents a session with the database
    public class ApplicationDbContext : DbContext 
    {
    // to pass the argent option to the class we use the word base 
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
       {

       }
       public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial data
            _ = modelBuilder.Entity<FoodItem>().HasData(
                new FoodItem { Id = 1, Name = "Burger", Description = "Delicious Burger", Price = 5.99M },
                new FoodItem { Id = 2, Name = "Pizza", Description = "Cheese Pizza", Price = 8.99M }
            );
        }
    }
}