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
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Sex> Sexs { get; set; }


        public DbSet<Group> Groups { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<ScheduleWorkday> ScheduleWorkdays { get; set; }
        public DbSet<ScheduleWorkout> ScheduleWorkouts { get; set; }
        public DbSet<WorkoutType> WorkoutTypes { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: what this HasMaxLength
            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(300);

            });

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Client" },
                new Role { Id = 2, Name = "Coach" },
                new Role { Id = 3, Name = "Admin" }
            );

            modelBuilder.Entity<Sex>().HasData(
             new Role { Id = 1, Name = "Male" },
             new Role { Id = 2, Name = "Female" } 
            );

            //modelBuilder.Entity<Status>().HasData(
            //    new Status { Id = 1, Name = "Main coach", RoleId = 2 },
            //    new Status { Id = 2, Name = "Coach", RoleId = 2 },  
            //    new Status { Id = 3, Name = "Senior gym coach", RoleId = 2 },

            //    new Status { Id = 4, Name = "Manager", RoleId = 3 },
            //    new Status { Id = 5, Name = "Head manager of the hall", RoleId = 3 }
            //);

            modelBuilder.Entity<Specialization>().HasData(
                new Specialization { Id = 1, Name = "Individual training" },
                new Specialization { Id = 2, Name = "Dance" },
                new Specialization { Id = 3, Name = "Yoga" }
            );


            string pwd = "123456789";
            SL._SL.CreatePasswordHash(pwd, out byte[] hashPwd, out byte[] hashSalt);

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FirstName = "Jeka",
                LastName = "LN",
                MiddletName = "MN", 
                BirthDate = new DateTime(2001, 01, 31),
                RoleId = 2,
                Login = "12345",
                PasswordHash = hashPwd,
                PasswordSalt = hashSalt,
                SexId = 1,
                StatusId = 1,
                SpecializationId = 1
            });


            modelBuilder.Entity<Phone>().HasData(
               new Phone { Id = 1, Number = 982885884, UserId = 1 },
               new Phone { Id = 2, Number = 982881234, UserId = 1 },
               new Phone { Id = 3, Number = 982348884, UserId = 1 }
           );

        }
    }
}
