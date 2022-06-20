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
        
        public DbSet<_RefreshToken> RefreshTokens { get; set; }


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

            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, Name = "Main coach", RoleId = 2 },
                new Status { Id = 2, Name = "Coach", RoleId = 2 },
                new Status { Id = 3, Name = "Senior gym coach", RoleId = 2 },

                new Status { Id = 4, Name = "Manager", RoleId = 3 },
                new Status { Id = 5, Name = "Head manager of the hall", RoleId = 3 }
            );

            modelBuilder.Entity<Specialization>().HasData(
                new Specialization { Id = 1, Name = "Individual training" },
                new Specialization { Id = 2, Name = "Dance" },
                new Specialization { Id = 3, Name = "Yoga" }
            );

            modelBuilder.Entity<WorkoutType>().HasData(
               new WorkoutType() { Id = 1, Name = "Group Type" },
               new WorkoutType() { Id = 2, Name = "Personal Type" }
            ); 

            modelBuilder.Entity<Group>().HasData(
                 new Group { Id = 1, Name = "GR-1" },
                 new Group { Id = 2, Name = "GR-2" }, 
                 new Group { Id = 3, Name = "GR-3" }
            );


            //modelBuilder
            //    .Entity<User>()
            //    .HasMany(p => p.Groups)
            //    .WithMany(p => p.Users)
            //    .UsingEntity(j => j.ToTable("GroupUser"));

            

            string pwd = "123456789";
            SL._SL.CreatePasswordHash(pwd, out byte[] hashPwd, out byte[] hashSalt);

            // coach 
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FirstName = "Jeka",
                LastName = "LN",
                MiddleName = "MN", 
                BirthDate = new DateTime(2001, 01, 31),
                RoleId = 2,
                Login = "12345",
                PasswordHash = hashPwd,
                PasswordSalt = hashSalt,
                SexId = 1,
                StatusId = 1,
                SpecializationId = 1
            });

            // client 
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                FirstName = "Rose",
                LastName = "RN",
                MiddleName = "RM",
                BirthDate = new DateTime(2001, 01, 31),
                RoleId = 1,
                Login = "12345",
                PasswordHash = hashPwd,
                PasswordSalt = hashSalt,
                SexId = 2,
            });


            modelBuilder.Entity<Phone>().HasData(
               new Phone { Id = 1, Number = 982885884, UserId = 1 },
               new Phone { Id = 2, Number = 982881234, UserId = 1 },
               new Phone { Id = 3, Number = 982348884, UserId = 1 }
           );

            modelBuilder.Entity<Room>().HasData(
                new Room()
                {
                    Id = 1,
                    Number = 201,
                    Name = "Large Dance Room",
                    AreaSize = 20,
                    Floor = 2
                }); 

            DateTime currentTime = DateTime.Now;
            
            modelBuilder.Entity<ScheduleWorkday>().HasData(
                new ScheduleWorkday()
                {
                    Id = 1,
                    Date = new DateTime(2022, 6, 18), 
                    CoachId = 1,
                    StartTime = new DateTime(2022, 6, 18, 9, 0, 0),
                    EndTime = new DateTime(2022, 6, 18, 18, 0, 0),
                }
            );

           // workout for group type

           modelBuilder.Entity<ScheduleWorkout>().HasData(
              new ScheduleWorkout()
              {
                  Id = 1,
                  SheduleWorkdayId = 1,
                  GroupId = 1,
                  RoomId = 1,
                  WorkoutTypeId = 1,
                  start = new DateTime(2022, 6, 18, 9, 0, 0),
                  end = new DateTime(2022, 6, 18, 12, 0, 0),
              }
          );

            modelBuilder.Entity<ScheduleWorkout>().HasData(
            new ScheduleWorkout()
            {
                Id = 2,
                SheduleWorkdayId = 1,
                RoomId = 1,
                ClientId = 1,
                WorkoutTypeId = 2,
                start = new DateTime(2022, 6, 18, 12, 0, 0),
                end = new DateTime(2022, 6, 18, 15, 0, 0),
            }
        );

        }
    }
}
