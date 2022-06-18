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
    [Migration("20220618164613_CreateInitial")]
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

                    b.Property<string>("MiddletName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("SexId")
                        .HasColumnType("int");

                    b.Property<int?>("SpecializationId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TokenCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TokenExpires")
                        .HasColumnType("datetime2");

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
                            MiddletName = "MN",
                            PasswordHash = new byte[] { 129, 80, 172, 109, 120, 100, 188, 75, 69, 80, 27, 77, 138, 81, 76, 60, 195, 13, 156, 171, 124, 126, 124, 109, 31, 134, 42, 153, 242, 200, 214, 159, 38, 144, 31, 221, 106, 248, 38, 127, 66, 88, 175, 172, 226, 46, 125, 41, 33, 150, 147, 245, 144, 86, 7, 53, 248, 98, 141, 26, 52, 114, 68, 247 },
                            PasswordSalt = new byte[] { 115, 148, 225, 27, 170, 7, 195, 73, 82, 51, 84, 194, 7, 38, 52, 38, 88, 216, 73, 40, 75, 176, 155, 243, 43, 229, 100, 251, 208, 254, 67, 149, 215, 176, 127, 72, 84, 25, 240, 48, 180, 82, 33, 212, 106, 173, 21, 30, 213, 182, 159, 76, 181, 182, 133, 173, 164, 21, 2, 186, 13, 22, 34, 165, 237, 240, 24, 61, 251, 154, 116, 39, 19, 215, 161, 216, 94, 202, 45, 69, 174, 75, 53, 236, 98, 48, 203, 217, 133, 136, 17, 251, 108, 219, 233, 74, 236, 248, 244, 132, 69, 3, 26, 123, 66, 44, 231, 53, 152, 116, 116, 136, 233, 20, 215, 65, 179, 29, 185, 155, 32, 112, 152, 198, 234, 86, 21, 206 },
                            RoleId = 2,
                            SexId = 1,
                            SpecializationId = 1,
                            StatusId = 1,
                            TokenCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(2001, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Rose",
                            LastName = "RN",
                            Login = "12345",
                            MiddletName = "RM",
                            PasswordHash = new byte[] { 129, 80, 172, 109, 120, 100, 188, 75, 69, 80, 27, 77, 138, 81, 76, 60, 195, 13, 156, 171, 124, 126, 124, 109, 31, 134, 42, 153, 242, 200, 214, 159, 38, 144, 31, 221, 106, 248, 38, 127, 66, 88, 175, 172, 226, 46, 125, 41, 33, 150, 147, 245, 144, 86, 7, 53, 248, 98, 141, 26, 52, 114, 68, 247 },
                            PasswordSalt = new byte[] { 115, 148, 225, 27, 170, 7, 195, 73, 82, 51, 84, 194, 7, 38, 52, 38, 88, 216, 73, 40, 75, 176, 155, 243, 43, 229, 100, 251, 208, 254, 67, 149, 215, 176, 127, 72, 84, 25, 240, 48, 180, 82, 33, 212, 106, 173, 21, 30, 213, 182, 159, 76, 181, 182, 133, 173, 164, 21, 2, 186, 13, 22, 34, 165, 237, 240, 24, 61, 251, 154, 116, 39, 19, 215, 161, 216, 94, 202, 45, 69, 174, 75, 53, 236, 98, 48, 203, 217, 133, 136, 17, 251, 108, 219, 233, 74, 236, 248, 244, 132, 69, 3, 26, 123, 66, 44, 231, 53, 152, 116, 116, 136, 233, 20, 215, 65, 179, 29, 185, 155, 32, 112, 152, 198, 234, 86, 21, 206 },
                            RoleId = 1,
                            SexId = 2,
                            TokenCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
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

            modelBuilder.Entity("SportAccountApi.Models.User", b =>
                {
                    b.Navigation("Phones");
                });
#pragma warning restore 612, 618
        }
    }
}