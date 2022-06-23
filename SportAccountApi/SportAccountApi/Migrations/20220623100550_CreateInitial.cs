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
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                values: new object[] { 1, (short)20, (short)2, "Large Dance Room", 201 });

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
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName", "Login", "MiddleName", "PasswordHash", "PasswordSalt", "RoleId", "SexId", "SpecializationId", "StatusId" },
                values: new object[,]
                {
                    { 3, new DateTime(1995, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mike", "Clark", "123456", null, new byte[] { 76, 222, 227, 104, 51, 68, 1, 161, 65, 82, 37, 74, 143, 7, 81, 151, 123, 11, 156, 243, 211, 94, 177, 35, 124, 217, 33, 186, 143, 173, 214, 169, 91, 233, 134, 190, 201, 229, 230, 90, 20, 117, 61, 83, 21, 120, 131, 97, 66, 61, 162, 246, 149, 27, 2, 152, 180, 179, 104, 243, 155, 245, 155, 227 }, new byte[] { 114, 175, 177, 238, 77, 184, 188, 52, 69, 177, 114, 84, 195, 164, 221, 167, 63, 127, 136, 42, 220, 208, 83, 40, 48, 131, 237, 205, 54, 124, 177, 202, 55, 82, 186, 108, 87, 33, 136, 160, 239, 119, 132, 107, 64, 43, 37, 119, 112, 115, 105, 66, 139, 163, 137, 54, 26, 240, 101, 0, 138, 187, 56, 178, 236, 17, 211, 33, 22, 227, 98, 255, 189, 184, 165, 14, 173, 146, 230, 223, 70, 126, 182, 158, 82, 101, 132, 151, 206, 56, 8, 35, 244, 47, 180, 180, 23, 178, 122, 61, 91, 17, 107, 203, 199, 99, 194, 189, 193, 211, 192, 180, 101, 177, 63, 233, 113, 150, 117, 95, 86, 173, 154, 68, 84, 19, 231, 83 }, 1, 1, null, null },
                    { 4, new DateTime(1995, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jackson", "Sweem", "qwerty", null, new byte[] { 76, 222, 227, 104, 51, 68, 1, 161, 65, 82, 37, 74, 143, 7, 81, 151, 123, 11, 156, 243, 211, 94, 177, 35, 124, 217, 33, 186, 143, 173, 214, 169, 91, 233, 134, 190, 201, 229, 230, 90, 20, 117, 61, 83, 21, 120, 131, 97, 66, 61, 162, 246, 149, 27, 2, 152, 180, 179, 104, 243, 155, 245, 155, 227 }, new byte[] { 114, 175, 177, 238, 77, 184, 188, 52, 69, 177, 114, 84, 195, 164, 221, 167, 63, 127, 136, 42, 220, 208, 83, 40, 48, 131, 237, 205, 54, 124, 177, 202, 55, 82, 186, 108, 87, 33, 136, 160, 239, 119, 132, 107, 64, 43, 37, 119, 112, 115, 105, 66, 139, 163, 137, 54, 26, 240, 101, 0, 138, 187, 56, 178, 236, 17, 211, 33, 22, 227, 98, 255, 189, 184, 165, 14, 173, 146, 230, 223, 70, 126, 182, 158, 82, 101, 132, 151, 206, 56, 8, 35, 244, 47, 180, 180, 23, 178, 122, 61, 91, 17, 107, 203, 199, 99, 194, 189, 193, 211, 192, 180, 101, 177, 63, 233, 113, 150, 117, 95, 86, 173, 154, 68, 84, 19, 231, 83 }, 1, 1, null, null },
                    { 5, new DateTime(1980, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Cook", "111", null, new byte[] { 76, 222, 227, 104, 51, 68, 1, 161, 65, 82, 37, 74, 143, 7, 81, 151, 123, 11, 156, 243, 211, 94, 177, 35, 124, 217, 33, 186, 143, 173, 214, 169, 91, 233, 134, 190, 201, 229, 230, 90, 20, 117, 61, 83, 21, 120, 131, 97, 66, 61, 162, 246, 149, 27, 2, 152, 180, 179, 104, 243, 155, 245, 155, 227 }, new byte[] { 114, 175, 177, 238, 77, 184, 188, 52, 69, 177, 114, 84, 195, 164, 221, 167, 63, 127, 136, 42, 220, 208, 83, 40, 48, 131, 237, 205, 54, 124, 177, 202, 55, 82, 186, 108, 87, 33, 136, 160, 239, 119, 132, 107, 64, 43, 37, 119, 112, 115, 105, 66, 139, 163, 137, 54, 26, 240, 101, 0, 138, 187, 56, 178, 236, 17, 211, 33, 22, 227, 98, 255, 189, 184, 165, 14, 173, 146, 230, 223, 70, 126, 182, 158, 82, 101, 132, 151, 206, 56, 8, 35, 244, 47, 180, 180, 23, 178, 122, 61, 91, 17, 107, 203, 199, 99, 194, 189, 193, 211, 192, 180, 101, 177, 63, 233, 113, 150, 117, 95, 86, 173, 154, 68, 84, 19, 231, 83 }, 3, 1, null, null },
                    { 2, new DateTime(2001, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rose", "Menders", "12345", null, new byte[] { 76, 222, 227, 104, 51, 68, 1, 161, 65, 82, 37, 74, 143, 7, 81, 151, 123, 11, 156, 243, 211, 94, 177, 35, 124, 217, 33, 186, 143, 173, 214, 169, 91, 233, 134, 190, 201, 229, 230, 90, 20, 117, 61, 83, 21, 120, 131, 97, 66, 61, 162, 246, 149, 27, 2, 152, 180, 179, 104, 243, 155, 245, 155, 227 }, new byte[] { 114, 175, 177, 238, 77, 184, 188, 52, 69, 177, 114, 84, 195, 164, 221, 167, 63, 127, 136, 42, 220, 208, 83, 40, 48, 131, 237, 205, 54, 124, 177, 202, 55, 82, 186, 108, 87, 33, 136, 160, 239, 119, 132, 107, 64, 43, 37, 119, 112, 115, 105, 66, 139, 163, 137, 54, 26, 240, 101, 0, 138, 187, 56, 178, 236, 17, 211, 33, 22, 227, 98, 255, 189, 184, 165, 14, 173, 146, 230, 223, 70, 126, 182, 158, 82, 101, 132, 151, 206, 56, 8, 35, 244, 47, 180, 180, 23, 178, 122, 61, 91, 17, 107, 203, 199, 99, 194, 189, 193, 211, 192, 180, 101, 177, 63, 233, 113, 150, 117, 95, 86, 173, 154, 68, 84, 19, 231, 83 }, 1, 2, null, null }
                });

            migrationBuilder.InsertData(
                table: "GroupUser",
                columns: new[] { "GroupsId", "UsersId" },
                values: new object[,]
                {
                    { 1, 3 },
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
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName", "Login", "MiddleName", "PasswordHash", "PasswordSalt", "RoleId", "SexId", "SpecializationId", "StatusId" },
                values: new object[] { 1, new DateTime(2001, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeka", "LN", "1", "MN", new byte[] { 76, 222, 227, 104, 51, 68, 1, 161, 65, 82, 37, 74, 143, 7, 81, 151, 123, 11, 156, 243, 211, 94, 177, 35, 124, 217, 33, 186, 143, 173, 214, 169, 91, 233, 134, 190, 201, 229, 230, 90, 20, 117, 61, 83, 21, 120, 131, 97, 66, 61, 162, 246, 149, 27, 2, 152, 180, 179, 104, 243, 155, 245, 155, 227 }, new byte[] { 114, 175, 177, 238, 77, 184, 188, 52, 69, 177, 114, 84, 195, 164, 221, 167, 63, 127, 136, 42, 220, 208, 83, 40, 48, 131, 237, 205, 54, 124, 177, 202, 55, 82, 186, 108, 87, 33, 136, 160, 239, 119, 132, 107, 64, 43, 37, 119, 112, 115, 105, 66, 139, 163, 137, 54, 26, 240, 101, 0, 138, 187, 56, 178, 236, 17, 211, 33, 22, 227, 98, 255, 189, 184, 165, 14, 173, 146, 230, 223, 70, 126, 182, 158, 82, 101, 132, 151, 206, 56, 8, 35, 244, 47, 180, 180, 23, 178, 122, 61, 91, 17, 107, 203, 199, 99, 194, 189, 193, 211, 192, 180, 101, 177, 63, 233, 113, 150, 117, 95, 86, 173, 154, 68, 84, 19, 231, 83 }, 2, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "GroupUser",
                columns: new[] { "GroupsId", "UsersId" },
                values: new object[] { 2, 1 });

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
                values: new object[] { 1, 1, new DateTime(2022, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 18, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 18, 9, 0, 0, 0, DateTimeKind.Unspecified) });

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
