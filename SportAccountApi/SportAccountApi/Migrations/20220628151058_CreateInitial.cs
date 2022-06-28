using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportAccountApi.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaSize = table.Column<short>(type: "smallint", nullable: false),
                    Floor = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sexs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statuses_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpecializationId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    SexId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Sexs_SexId",
                        column: x => x.SexId,
                        principalTable: "Sexs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupUser",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUser", x => new { x.GroupsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_GroupUser_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expired_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleWorkdays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoachId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleWorkdays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleWorkdays_Users_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleWorkouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SheduleWorkdayId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    WorkoutTypeId = table.Column<int>(type: "int", nullable: false),
                    start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleWorkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleWorkouts_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleWorkouts_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleWorkouts_ScheduleWorkdays_SheduleWorkdayId",
                        column: x => x.SheduleWorkdayId,
                        principalTable: "ScheduleWorkdays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleWorkouts_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleWorkouts_WorkoutTypes_WorkoutTypeId",
                        column: x => x.WorkoutTypeId,
                        principalTable: "WorkoutTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "GR-1" },
                    { 2, "GR-2" },
                    { 3, "GR-3" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Client" },
                    { 2, "Coach" },
                    { 3, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "AreaSize", "Floor", "Name", "Number" },
                values: new object[,]
                {
                    { 1, (short)20, (short)2, "Large Dance Room", 201 },
                    { 2, (short)10, (short)2, "Middle Fitness Room", 205 }
                });

            migrationBuilder.InsertData(
                table: "Sexs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" }
                });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Individual training" },
                    { 2, "Dance" },
                    { 3, "Yoga" }
                });

            migrationBuilder.InsertData(
                table: "WorkoutTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Group Type" },
                    { 2, "Personal Type" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name", "RoleId" },
                values: new object[,]
                {
                    { 1, "Main coach", 2 },
                    { 2, "Coach", 2 },
                    { 3, "Senior gym coach", 2 },
                    { 4, "Manager", 3 },
                    { 5, "Head manager of the hall", 3 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Login", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordSalt", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "SexId", "SpecializationId", "StatusId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 3, 0, new DateTime(1995, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "9f2cadab-160f-4f67-9cab-68440283e6bd", null, false, "Mike", "Clark", false, null, "client2", null, null, null, new byte[] { 123, 55, 13, 51, 76, 218, 17, 53, 68, 101, 201, 173, 98, 37, 207, 86, 177, 45, 14, 21, 18, 229, 249, 37, 132, 33, 243, 238, 138, 226, 2, 89, 107, 5, 65, 244, 218, 240, 101, 40, 194, 139, 52, 43, 34, 168, 5, 223, 108, 41, 133, 191, 227, 134, 107, 93, 218, 178, 15, 237, 156, 196, 236, 135 }, new byte[] { 125, 208, 163, 89, 206, 129, 236, 76, 5, 222, 211, 237, 221, 210, 212, 74, 43, 200, 113, 106, 226, 126, 186, 121, 28, 11, 155, 17, 201, 145, 7, 180, 245, 37, 235, 192, 140, 92, 160, 244, 35, 25, 31, 235, 231, 18, 45, 64, 74, 71, 81, 2, 208, 229, 153, 100, 158, 10, 252, 96, 22, 124, 106, 143, 165, 111, 136, 23, 228, 35, 67, 171, 249, 163, 47, 143, 145, 62, 138, 4, 83, 157, 143, 176, 209, 110, 72, 78, 55, 104, 22, 129, 173, 225, 207, 51, 126, 237, 144, 107, 27, 66, 112, 79, 104, 133, 203, 154, 157, 132, 157, 105, 175, 60, 205, 140, 137, 142, 40, 86, 212, 73, 152, 134, 240, 72, 131, 115 }, null, false, 1, "b00b866b-a408-4ec2-bbed-54f76f98126e", 1, null, null, false, null },
                    { 4, 0, new DateTime(1995, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "5d60b632-5e63-4e26-808c-a7fe83a730c5", null, false, "Jackson", "Sweem", false, null, "client3", null, null, null, new byte[] { 123, 55, 13, 51, 76, 218, 17, 53, 68, 101, 201, 173, 98, 37, 207, 86, 177, 45, 14, 21, 18, 229, 249, 37, 132, 33, 243, 238, 138, 226, 2, 89, 107, 5, 65, 244, 218, 240, 101, 40, 194, 139, 52, 43, 34, 168, 5, 223, 108, 41, 133, 191, 227, 134, 107, 93, 218, 178, 15, 237, 156, 196, 236, 135 }, new byte[] { 125, 208, 163, 89, 206, 129, 236, 76, 5, 222, 211, 237, 221, 210, 212, 74, 43, 200, 113, 106, 226, 126, 186, 121, 28, 11, 155, 17, 201, 145, 7, 180, 245, 37, 235, 192, 140, 92, 160, 244, 35, 25, 31, 235, 231, 18, 45, 64, 74, 71, 81, 2, 208, 229, 153, 100, 158, 10, 252, 96, 22, 124, 106, 143, 165, 111, 136, 23, 228, 35, 67, 171, 249, 163, 47, 143, 145, 62, 138, 4, 83, 157, 143, 176, 209, 110, 72, 78, 55, 104, 22, 129, 173, 225, 207, 51, 126, 237, 144, 107, 27, 66, 112, 79, 104, 133, 203, 154, 157, 132, 157, 105, 175, 60, 205, 140, 137, 142, 40, 86, 212, 73, 152, 134, 240, 72, 131, 115 }, null, false, 1, "9750915e-93b8-47a5-9fa1-f5265f14e388", 1, null, null, false, null },
                    { 5, 0, new DateTime(1980, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "feb1c59f-5b19-46bc-b4d7-227b0d6c125f", null, false, "John", "Cook", false, null, "admin", null, null, null, new byte[] { 123, 55, 13, 51, 76, 218, 17, 53, 68, 101, 201, 173, 98, 37, 207, 86, 177, 45, 14, 21, 18, 229, 249, 37, 132, 33, 243, 238, 138, 226, 2, 89, 107, 5, 65, 244, 218, 240, 101, 40, 194, 139, 52, 43, 34, 168, 5, 223, 108, 41, 133, 191, 227, 134, 107, 93, 218, 178, 15, 237, 156, 196, 236, 135 }, new byte[] { 125, 208, 163, 89, 206, 129, 236, 76, 5, 222, 211, 237, 221, 210, 212, 74, 43, 200, 113, 106, 226, 126, 186, 121, 28, 11, 155, 17, 201, 145, 7, 180, 245, 37, 235, 192, 140, 92, 160, 244, 35, 25, 31, 235, 231, 18, 45, 64, 74, 71, 81, 2, 208, 229, 153, 100, 158, 10, 252, 96, 22, 124, 106, 143, 165, 111, 136, 23, 228, 35, 67, 171, 249, 163, 47, 143, 145, 62, 138, 4, 83, 157, 143, 176, 209, 110, 72, 78, 55, 104, 22, 129, 173, 225, 207, 51, 126, 237, 144, 107, 27, 66, 112, 79, 104, 133, 203, 154, 157, 132, 157, 105, 175, 60, 205, 140, 137, 142, 40, 86, 212, 73, 152, 134, 240, 72, 131, 115 }, null, false, 3, "f6000be8-e6b9-48b5-bbd1-621c8ad99b0b", 1, null, null, false, null },
                    { 2, 0, new DateTime(2001, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "db3257be-8da7-483f-ac19-23881b78d4e2", null, false, "Rose", "Menders", false, null, "client1", null, null, null, new byte[] { 123, 55, 13, 51, 76, 218, 17, 53, 68, 101, 201, 173, 98, 37, 207, 86, 177, 45, 14, 21, 18, 229, 249, 37, 132, 33, 243, 238, 138, 226, 2, 89, 107, 5, 65, 244, 218, 240, 101, 40, 194, 139, 52, 43, 34, 168, 5, 223, 108, 41, 133, 191, 227, 134, 107, 93, 218, 178, 15, 237, 156, 196, 236, 135 }, new byte[] { 125, 208, 163, 89, 206, 129, 236, 76, 5, 222, 211, 237, 221, 210, 212, 74, 43, 200, 113, 106, 226, 126, 186, 121, 28, 11, 155, 17, 201, 145, 7, 180, 245, 37, 235, 192, 140, 92, 160, 244, 35, 25, 31, 235, 231, 18, 45, 64, 74, 71, 81, 2, 208, 229, 153, 100, 158, 10, 252, 96, 22, 124, 106, 143, 165, 111, 136, 23, 228, 35, 67, 171, 249, 163, 47, 143, 145, 62, 138, 4, 83, 157, 143, 176, 209, 110, 72, 78, 55, 104, 22, 129, 173, 225, 207, 51, 126, 237, 144, 107, 27, 66, 112, 79, 104, 133, 203, 154, 157, 132, 157, 105, 175, 60, 205, 140, 137, 142, 40, 86, 212, 73, 152, 134, 240, 72, 131, 115 }, null, false, 1, "5ed4a647-667a-4456-823b-04893470d0e5", 2, null, null, false, null }
                });

            migrationBuilder.InsertData(
                table: "GroupUser",
                columns: new[] { "GroupsId", "UsersId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 4 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Number", "UserId" },
                values: new object[,]
                {
                    { 5, 982834884, 3 },
                    { 4, 982685784, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Login", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordSalt", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "SexId", "SpecializationId", "StatusId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2001, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "447ceab6-5c02-4cb4-a16d-0296fe22112f", null, false, "Jeka", "LN", false, null, "coach1", "MN", null, null, new byte[] { 123, 55, 13, 51, 76, 218, 17, 53, 68, 101, 201, 173, 98, 37, 207, 86, 177, 45, 14, 21, 18, 229, 249, 37, 132, 33, 243, 238, 138, 226, 2, 89, 107, 5, 65, 244, 218, 240, 101, 40, 194, 139, 52, 43, 34, 168, 5, 223, 108, 41, 133, 191, 227, 134, 107, 93, 218, 178, 15, 237, 156, 196, 236, 135 }, new byte[] { 125, 208, 163, 89, 206, 129, 236, 76, 5, 222, 211, 237, 221, 210, 212, 74, 43, 200, 113, 106, 226, 126, 186, 121, 28, 11, 155, 17, 201, 145, 7, 180, 245, 37, 235, 192, 140, 92, 160, 244, 35, 25, 31, 235, 231, 18, 45, 64, 74, 71, 81, 2, 208, 229, 153, 100, 158, 10, 252, 96, 22, 124, 106, 143, 165, 111, 136, 23, 228, 35, 67, 171, 249, 163, 47, 143, 145, 62, 138, 4, 83, 157, 143, 176, 209, 110, 72, 78, 55, 104, 22, 129, 173, 225, 207, 51, 126, 237, 144, 107, 27, 66, 112, 79, 104, 133, 203, 154, 157, 132, 157, 105, 175, 60, 205, 140, 137, 142, 40, 86, 212, 73, 152, 134, 240, 72, 131, 115 }, null, false, 2, "53ac0a87-3357-4d75-a9da-9e3ce362cf90", 1, 1, 1, false, null },
                    { 6, 0, new DateTime(1990, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "282bed1c-82a4-4545-ad98-f41eac643cfc", null, false, "David", "DL", false, null, "coach2", "DN", null, null, new byte[] { 123, 55, 13, 51, 76, 218, 17, 53, 68, 101, 201, 173, 98, 37, 207, 86, 177, 45, 14, 21, 18, 229, 249, 37, 132, 33, 243, 238, 138, 226, 2, 89, 107, 5, 65, 244, 218, 240, 101, 40, 194, 139, 52, 43, 34, 168, 5, 223, 108, 41, 133, 191, 227, 134, 107, 93, 218, 178, 15, 237, 156, 196, 236, 135 }, new byte[] { 125, 208, 163, 89, 206, 129, 236, 76, 5, 222, 211, 237, 221, 210, 212, 74, 43, 200, 113, 106, 226, 126, 186, 121, 28, 11, 155, 17, 201, 145, 7, 180, 245, 37, 235, 192, 140, 92, 160, 244, 35, 25, 31, 235, 231, 18, 45, 64, 74, 71, 81, 2, 208, 229, 153, 100, 158, 10, 252, 96, 22, 124, 106, 143, 165, 111, 136, 23, 228, 35, 67, 171, 249, 163, 47, 143, 145, 62, 138, 4, 83, 157, 143, 176, 209, 110, 72, 78, 55, 104, 22, 129, 173, 225, 207, 51, 126, 237, 144, 107, 27, 66, 112, 79, 104, 133, 203, 154, 157, 132, 157, 105, 175, 60, 205, 140, 137, 142, 40, 86, 212, 73, 152, 134, 240, 72, 131, 115 }, null, false, 2, "8d21b751-f38d-452f-9347-0edd9716e160", 1, 1, 1, false, null }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Number", "UserId" },
                values: new object[,]
                {
                    { 1, 982885884, 1 },
                    { 2, 982881234, 1 },
                    { 3, 982348884, 1 }
                });

            migrationBuilder.InsertData(
                table: "ScheduleWorkdays",
                columns: new[] { "Id", "CoachId", "Date", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 18, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 18, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 6, new DateTime(2022, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 18, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 18, 9, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ScheduleWorkouts",
                columns: new[] { "Id", "ClientId", "GroupId", "RoomId", "SheduleWorkdayId", "WorkoutTypeId", "end", "start" },
                values: new object[] { 1, null, 1, 1, 1, 1, new DateTime(2022, 6, 18, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 18, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ScheduleWorkouts",
                columns: new[] { "Id", "ClientId", "GroupId", "RoomId", "SheduleWorkdayId", "WorkoutTypeId", "end", "start" },
                values: new object[] { 2, 1, null, 1, 1, 2, new DateTime(2022, 6, 18, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 18, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_UsersId",
                table: "GroupUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_UserId",
                table: "Phones",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleWorkdays_CoachId",
                table: "ScheduleWorkdays",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleWorkouts_ClientId",
                table: "ScheduleWorkouts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleWorkouts_GroupId",
                table: "ScheduleWorkouts",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleWorkouts_RoomId",
                table: "ScheduleWorkouts",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleWorkouts_SheduleWorkdayId",
                table: "ScheduleWorkouts",
                column: "SheduleWorkdayId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleWorkouts_WorkoutTypeId",
                table: "ScheduleWorkouts",
                column: "WorkoutTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_RoleId",
                table: "Statuses",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SexId",
                table: "Users",
                column: "SexId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SpecializationId",
                table: "Users",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StatusId",
                table: "Users",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupUser");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "ScheduleWorkouts");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "ScheduleWorkdays");

            migrationBuilder.DropTable(
                name: "WorkoutTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Sexs");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
