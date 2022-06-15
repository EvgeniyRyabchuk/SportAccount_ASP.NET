using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SportAccountApi.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; } 
        public DbSet<Role> Roles { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Client" },
                new Role { Id = 2, Name = "Coach" },
                new Role { Id = 3, Name = "Admin" }
            ); 


          modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1, 
                FirstName = "Jeka",
                LastName = "LN",
                MiddletName = "MN",
                BirthDate = new DateTime(2001, 01, 31),

            }); 

        }
    }
}
