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
                    MiddletName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName", "Login", "MiddletName", "PasswordHash", "PasswordSalt", "RefreshToken", "RoleId", "SexId", "SpecializationId", "StatusId", "TokenCreated", "TokenExpires" },
                values: new object[,]
                {
                    { 2, new DateTime(2001, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rose", "RN", "12345", "RM", new byte[] { 129, 80, 172, 109, 120, 100, 188, 75, 69, 80, 27, 77, 138, 81, 76, 60, 195, 13, 156, 171, 124, 126, 124, 109, 31, 134, 42, 153, 242, 200, 214, 159, 38, 144, 31, 221, 106, 248, 38, 127, 66, 88, 175, 172, 226, 46, 125, 41, 33, 150, 147, 245, 144, 86, 7, 53, 248, 98, 141, 26, 52, 114, 68, 247 }, new byte[] { 115, 148, 225, 27, 170, 7, 195, 73, 82, 51, 84, 194, 7, 38, 52, 38, 88, 216, 73, 40, 75, 176, 155, 243, 43, 229, 100, 251, 208, 254, 67, 149, 215, 176, 127, 72, 84, 25, 240, 48, 180, 82, 33, 212, 106, 173, 21, 30, 213, 182, 159, 76, 181, 182, 133, 173, 164, 21, 2, 186, 13, 22, 34, 165, 237, 240, 24, 61, 251, 154, 116, 39, 19, 215, 161, 216, 94, 202, 45, 69, 174, 75, 53, 236, 98, 48, 203, 217, 133, 136, 17, 251, 108, 219, 233, 74, 236, 248, 244, 132, 69, 3, 26, 123, 66, 44, 231, 53, 152, 116, 116, 136, 233, 20, 215, 65, 179, 29, 185, 155, 32, 112, 152, 198, 234, 86, 21, 206 }, null, 1, 2, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new DateTime(2001, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeka", "LN", "12345", "MN", new byte[] { 129, 80, 172, 109, 120, 100, 188, 75, 69, 80, 27, 77, 138, 81, 76, 60, 195, 13, 156, 171, 124, 126, 124, 109, 31, 134, 42, 153, 242, 200, 214, 159, 38, 144, 31, 221, 106, 248, 38, 127, 66, 88, 175, 172, 226, 46, 125, 41, 33, 150, 147, 245, 144, 86, 7, 53, 248, 98, 141, 26, 52, 114, 68, 247 }, new byte[] { 115, 148, 225, 27, 170, 7, 195, 73, 82, 51, 84, 194, 7, 38, 52, 38, 88, 216, 73, 40, 75, 176, 155, 243, 43, 229, 100, 251, 208, 254, 67, 149, 215, 176, 127, 72, 84, 25, 240, 48, 180, 82, 33, 212, 106, 173, 21, 30, 213, 182, 159, 76, 181, 182, 133, 173, 164, 21, 2, 186, 13, 22, 34, 165, 237, 240, 24, 61, 251, 154, 116, 39, 19, 215, 161, 216, 94, 202, 45, 69, 174, 75, 53, 236, 98, 48, 203, 217, 133, 136, 17, 251, 108, 219, 233, 74, 236, 248, 244, 132, 69, 3, 26, 123, 66, 44, 231, 53, 152, 116, 116, 136, 233, 20, 215, 65, 179, 29, 185, 155, 32, 112, 152, 198, 234, 86, 21, 206 }, null, 2, 1, 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
                values: new object[] { 1, 1, new DateTime(2022, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 18, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 18, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ScheduleWorkouts",
                columns: new[] { "Id", "ClientId", "GroupId", "RoomId", "SheduleWorkdayId", "WorkoutTypeId", "end", "start" },
                values: new object[] { 1, null, 1, 1, 1, 1, new DateTime(2022, 6, 18, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 18, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_UsersId",
                table: "GroupUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_UserId",
                table: "Phones",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupUser");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "ScheduleWorkouts");

            migrationBuilder.DropTable(
                name: "Statuses");

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
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Sexs");

            migrationBuilder.DropTable(
                name: "Specializations");
        }
    }
}
