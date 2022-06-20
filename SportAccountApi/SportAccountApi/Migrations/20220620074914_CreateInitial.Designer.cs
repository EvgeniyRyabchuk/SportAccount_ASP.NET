﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportAccountApi.Models;

namespace SportAccountApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220620074914_CreateInitial")]
    partial class CreateInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("GroupsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("GroupUser");
                });

            modelBuilder.Entity("SportAccountApi.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "GR-1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "GR-2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "GR-3"
                        });
                });

            modelBuilder.Entity("SportAccountApi.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Phones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Number = 982885884,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Number = 982881234,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Number = 982348884,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("SportAccountApi.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Client"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Coach"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("SportAccountApi.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("AreaSize")
                        .HasColumnType("smallint");

                    b.Property<short>("Floor")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AreaSize = (short)20,
                            Floor = (short)2,
                            Name = "Large Dance Room",
                            Number = 201
                        });
                });

            modelBuilder.Entity("SportAccountApi.Models.ScheduleWorkday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoachId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.ToTable("ScheduleWorkdays");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CoachId = 1,
                            Date = new DateTime(2022, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new DateTime(2022, 6, 18, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2022, 6, 18, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SportAccountApi.Models.ScheduleWorkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("SheduleWorkdayId")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("end")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("GroupId");

                    b.HasIndex("RoomId");

                    b.HasIndex("SheduleWorkdayId");

                    b.HasIndex("WorkoutTypeId");

                    b.ToTable("ScheduleWorkouts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GroupId = 1,
                            RoomId = 1,
                            SheduleWorkdayId = 1,
                            WorkoutTypeId = 1,
                            end = new DateTime(2022, 6, 18, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            start = new DateTime(2022, 6, 18, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SportAccountApi.Models.Sex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sexs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Male"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Female"
                        });
                });

            modelBuilder.Entity("SportAccountApi.Models.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specializations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Individual training"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dance"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Yoga"
                        });
                });

            modelBuilder.Entity("SportAccountApi.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Main coach",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 2,
                            Name = "Coach",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Senior gym coach",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Manager",
                            RoleId = 3
                        },
                        new
                        {
                            Id = 5,
                            Name = "Head manager of the hall",
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("SportAccountApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("SexId")
                        .HasColumnType("int");

                    b.Property<int?>("SpecializationId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("SexId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(2001, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Jeka",
                            LastName = "LN",
                            Login = "12345",
                            MiddleName = "MN",
                            PasswordHash = new byte[] { 13, 23, 30, 231, 154, 84, 66, 164, 65, 34, 17, 17, 53, 241, 22, 243, 147, 121, 101, 186, 199, 125, 254, 113, 118, 152, 62, 13, 91, 203, 212, 220, 62, 72, 224, 1, 24, 73, 214, 138, 93, 114, 193, 96, 32, 180, 140, 14, 50, 12, 0, 186, 243, 220, 36, 161, 219, 64, 115, 223, 20, 131, 208, 205 },
                            PasswordSalt = new byte[] { 67, 53, 232, 83, 161, 167, 87, 194, 222, 8, 145, 204, 40, 232, 14, 105, 40, 167, 179, 8, 3, 225, 105, 229, 68, 201, 240, 178, 101, 24, 235, 94, 37, 63, 113, 53, 143, 39, 109, 241, 151, 56, 102, 25, 191, 144, 82, 129, 198, 54, 166, 161, 197, 252, 131, 238, 28, 202, 78, 248, 248, 122, 171, 31, 27, 80, 164, 141, 71, 212, 127, 232, 201, 93, 117, 42, 114, 236, 206, 24, 169, 241, 110, 157, 180, 6, 14, 202, 93, 110, 28, 151, 55, 250, 2, 67, 29, 164, 212, 156, 252, 49, 70, 136, 207, 140, 65, 68, 151, 62, 110, 197, 98, 86, 191, 192, 208, 160, 39, 174, 60, 240, 193, 68, 229, 101, 52, 207 },
                            RoleId = 2,
                            SexId = 1,
                            SpecializationId = 1,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(2001, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Rose",
                            LastName = "RN",
                            Login = "12345",
                            MiddleName = "RM",
                            PasswordHash = new byte[] { 13, 23, 30, 231, 154, 84, 66, 164, 65, 34, 17, 17, 53, 241, 22, 243, 147, 121, 101, 186, 199, 125, 254, 113, 118, 152, 62, 13, 91, 203, 212, 220, 62, 72, 224, 1, 24, 73, 214, 138, 93, 114, 193, 96, 32, 180, 140, 14, 50, 12, 0, 186, 243, 220, 36, 161, 219, 64, 115, 223, 20, 131, 208, 205 },
                            PasswordSalt = new byte[] { 67, 53, 232, 83, 161, 167, 87, 194, 222, 8, 145, 204, 40, 232, 14, 105, 40, 167, 179, 8, 3, 225, 105, 229, 68, 201, 240, 178, 101, 24, 235, 94, 37, 63, 113, 53, 143, 39, 109, 241, 151, 56, 102, 25, 191, 144, 82, 129, 198, 54, 166, 161, 197, 252, 131, 238, 28, 202, 78, 248, 248, 122, 171, 31, 27, 80, 164, 141, 71, 212, 127, 232, 201, 93, 117, 42, 114, 236, 206, 24, 169, 241, 110, 157, 180, 6, 14, 202, 93, 110, 28, 151, 55, 250, 2, 67, 29, 164, 212, 156, 252, 49, 70, 136, 207, 140, 65, 68, 151, 62, 110, 197, 98, 86, 191, 192, 208, 160, 39, 174, 60, 240, 193, 68, 229, 101, 52, 207 },
                            RoleId = 1,
                            SexId = 2
                        });
                });

            modelBuilder.Entity("SportAccountApi.Models.WorkoutType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkoutTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Group Type"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Personal Type"
                        });
                });

            modelBuilder.Entity("SportAccountApi.Models._RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Expired_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.HasOne("SportAccountApi.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportAccountApi.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SportAccountApi.Models.Phone", b =>
                {
                    b.HasOne("SportAccountApi.Models.User", "User")
                        .WithMany("Phones")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SportAccountApi.Models.ScheduleWorkday", b =>
                {
                    b.HasOne("SportAccountApi.Models.User", "Coach")
                        .WithMany()
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");
                });

            modelBuilder.Entity("SportAccountApi.Models.ScheduleWorkout", b =>
                {
                    b.HasOne("SportAccountApi.Models.User", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("SportAccountApi.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.HasOne("SportAccountApi.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportAccountApi.Models.ScheduleWorkday", "SheduleWorkday")
                        .WithMany()
                        .HasForeignKey("SheduleWorkdayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportAccountApi.Models.WorkoutType", "WorkoutType")
                        .WithMany()
                        .HasForeignKey("WorkoutTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Group");

                    b.Navigation("Room");

                    b.Navigation("SheduleWorkday");

                    b.Navigation("WorkoutType");
                });

            modelBuilder.Entity("SportAccountApi.Models.Status", b =>
                {
                    b.HasOne("SportAccountApi.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SportAccountApi.Models.User", b =>
                {
                    b.HasOne("SportAccountApi.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportAccountApi.Models.Sex", "Sex")
                        .WithMany()
                        .HasForeignKey("SexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportAccountApi.Models.Specialization", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationId");

                    b.Navigation("Role");

                    b.Navigation("Sex");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("SportAccountApi.Models._RefreshToken", b =>
                {
                    b.HasOne("SportAccountApi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SportAccountApi.Models.User", b =>
                {
                    b.Navigation("Phones");
                });
#pragma warning restore 612, 618
        }
    }
}