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
                    { 3, new DateTime(1995, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mike", "Clark", "123456", null, new byte[] { 82, 190, 213, 169, 106, 90, 162, 208, 51, 136, 150, 33, 84, 59, 26, 136, 78, 98, 248, 38, 220, 186, 226, 208, 134, 143, 29, 251, 208, 230, 219, 243, 19, 254, 247, 137, 167, 181, 200, 177, 88, 253, 2, 203, 76, 35, 246, 44, 12, 44, 193, 12, 144, 97, 25, 211, 213, 190, 211, 62, 34, 10, 7, 134 }, new byte[] { 191, 216, 159, 196, 60, 97, 237, 251, 84, 66, 124, 127, 68, 76, 121, 21, 21, 37, 27, 111, 206, 125, 29, 4, 14, 51, 76, 153, 74, 164, 116, 37, 142, 228, 190, 161, 129, 79, 180, 110, 13, 43, 50, 21, 130, 179, 211, 141, 204, 36, 90, 43, 115, 72, 23, 233, 250, 43, 127, 177, 207, 255, 7, 142, 233, 8, 130, 66, 107, 164, 181, 38, 75, 38, 245, 169, 169, 176, 238, 255, 217, 18, 72, 138, 53, 95, 106, 254, 23, 30, 107, 103, 10, 230, 234, 187, 25, 49, 248, 132, 7, 107, 253, 170, 231, 45, 62, 176, 4, 116, 55, 173, 36, 210, 166, 228, 123, 217, 99, 148, 148, 17, 151, 206, 33, 104, 173, 55 }, 1, 1, null, null },
                    { 4, new DateTime(1995, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jackson", "Sweem", "qwerty", null, new byte[] { 82, 190, 213, 169, 106, 90, 162, 208, 51, 136, 150, 33, 84, 59, 26, 136, 78, 98, 248, 38, 220, 186, 226, 208, 134, 143, 29, 251, 208, 230, 219, 243, 19, 254, 247, 137, 167, 181, 200, 177, 88, 253, 2, 203, 76, 35, 246, 44, 12, 44, 193, 12, 144, 97, 25, 211, 213, 190, 211, 62, 34, 10, 7, 134 }, new byte[] { 191, 216, 159, 196, 60, 97, 237, 251, 84, 66, 124, 127, 68, 76, 121, 21, 21, 37, 27, 111, 206, 125, 29, 4, 14, 51, 76, 153, 74, 164, 116, 37, 142, 228, 190, 161, 129, 79, 180, 110, 13, 43, 50, 21, 130, 179, 211, 141, 204, 36, 90, 43, 115, 72, 23, 233, 250, 43, 127, 177, 207, 255, 7, 142, 233, 8, 130, 66, 107, 164, 181, 38, 75, 38, 245, 169, 169, 176, 238, 255, 217, 18, 72, 138, 53, 95, 106, 254, 23, 30, 107, 103, 10, 230, 234, 187, 25, 49, 248, 132, 7, 107, 253, 170, 231, 45, 62, 176, 4, 116, 55, 173, 36, 210, 166, 228, 123, 217, 99, 148, 148, 17, 151, 206, 33, 104, 173, 55 }, 1, 1, null, null },
                    { 5, new DateTime(1980, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Cook", "111", null, new byte[] { 82, 190, 213, 169, 106, 90, 162, 208, 51, 136, 150, 33, 84, 59, 26, 136, 78, 98, 248, 38, 220, 186, 226, 208, 134, 143, 29, 251, 208, 230, 219, 243, 19, 254, 247, 137, 167, 181, 200, 177, 88, 253, 2, 203, 76, 35, 246, 44, 12, 44, 193, 12, 144, 97, 25, 211, 213, 190, 211, 62, 34, 10, 7, 134 }, new byte[] { 191, 216, 159, 196, 60, 97, 237, 251, 84, 66, 124, 127, 68, 76, 121, 21, 21, 37, 27, 111, 206, 125, 29, 4, 14, 51, 76, 153, 74, 164, 116, 37, 142, 228, 190, 161, 129, 79, 180, 110, 13, 43, 50, 21, 130, 179, 211, 141, 204, 36, 90, 43, 115, 72, 23, 233, 250, 43, 127, 177, 207, 255, 7, 142, 233, 8, 130, 66, 107, 164, 181, 38, 75, 38, 245, 169, 169, 176, 238, 255, 217, 18, 72, 138, 53, 95, 106, 254, 23, 30, 107, 103, 10, 230, 234, 187, 25, 49, 248, 132, 7, 107, 253, 170, 231, 45, 62, 176, 4, 116, 55, 173, 36, 210, 166, 228, 123, 217, 99, 148, 148, 17, 151, 206, 33, 104, 173, 55 }, 3, 1, null, null },
                    { 2, new DateTime(2001, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rose", "Menders", "12345", null, new byte[] { 82, 190, 213, 169, 106, 90, 162, 208, 51, 136, 150, 33, 84, 59, 26, 136, 78, 98, 248, 38, 220, 186, 226, 208, 134, 143, 29, 251, 208, 230, 219, 243, 19, 254, 247, 137, 167, 181, 200, 177, 88, 253, 2, 203, 76, 35, 246, 44, 12, 44, 193, 12, 144, 97, 25, 211, 213, 190, 211, 62, 34, 10, 7, 134 }, new byte[] { 191, 216, 159, 196, 60, 97, 237, 251, 84, 66, 124, 127, 68, 76, 121, 21, 21, 37, 27, 111, 206, 125, 29, 4, 14, 51, 76, 153, 74, 164, 116, 37, 142, 228, 190, 161, 129, 79, 180, 110, 13, 43, 50, 21, 130, 179, 211, 141, 204, 36, 90, 43, 115, 72, 23, 233, 250, 43, 127, 177, 207, 255, 7, 142, 233, 8, 130, 66, 107, 164, 181, 38, 75, 38, 245, 169, 169, 176, 238, 255, 217, 18, 72, 138, 53, 95, 106, 254, 23, 30, 107, 103, 10, 230, 234, 187, 25, 49, 248, 132, 7, 107, 253, 170, 231, 45, 62, 176, 4, 116, 55, 173, 36, 210, 166, 228, 123, 217, 99, 148, 148, 17, 151, 206, 33, 104, 173, 55 }, 1, 2, null, null }
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
                values: new object[] { 1, new DateTime(2001, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeka", "LN", "1", "MN", new byte[] { 82, 190, 213, 169, 106, 90, 162, 208, 51, 136, 150, 33, 84, 59, 26, 136, 78, 98, 248, 38, 220, 186, 226, 208, 134, 143, 29, 251, 208, 230, 219, 243, 19, 254, 247, 137, 167, 181, 200, 177, 88, 253, 2, 203, 76, 35, 246, 44, 12, 44, 193, 12, 144, 97, 25, 211, 213, 190, 211, 62, 34, 10, 7, 134 }, new byte[] { 191, 216, 159, 196, 60, 97, 237, 251, 84, 66, 124, 127, 68, 76, 121, 21, 21, 37, 27, 111, 206, 125, 29, 4, 14, 51, 76, 153, 74, 164, 116, 37, 142, 228, 190, 161, 129, 79, 180, 110, 13, 43, 50, 21, 130, 179, 211, 141, 204, 36, 90, 43, 115, 72, 23, 233, 250, 43, 127, 177, 207, 255, 7, 142, 233, 8, 130, 66, 107, 164, 181, 38, 75, 38, 245, 169, 169, 176, 238, 255, 217, 18, 72, 138, 53, 95, 106, 254, 23, 30, 107, 103, 10, 230, 234, 187, 25, 49, 248, 132, 7, 107, 253, 170, 231, 45, 62, 176, 4, 116, 55, 173, 36, 210, 166, 228, 123, 217, 99, 148, 148, 17, 151, 206, 33, 104, 173, 55 }, 2, 1, 1, 1 });

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
