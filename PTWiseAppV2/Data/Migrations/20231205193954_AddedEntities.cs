using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PTWiseAppV2.Migrations
{
    /// <inheritdoc />
    public partial class AddedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDateTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GymName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainerId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ClientId1 = table.Column<int>(type: "int", nullable: true),
                    TrainerId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Clients_ClientId1",
                        column: x => x.ClientId1,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Trainers_TrainerId1",
                        column: x => x.TrainerId1,
                        principalTable: "Trainers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    DurationMins = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workouts_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExerciseType = table.Column<int>(type: "int", nullable: false),
                    Sets = table.Column<int>(type: "int", nullable: false),
                    Reps = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestPeriodSeconds = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    WorkoutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "Country", "DateOfBirth", "Email", "FirstName", "GymName", "LastName", "Postcode", "TelephoneNumber", "Title" },
                values: new object[,]
                {
                    { 1, "5 Geraldine Road", null, "United Kingdom", new DateTime(1970, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "johnpalmer@ptwise.com", "John", "PT Wise Gym", "Palmer", "WR14 3SZ", "1234567890", "Mr" },
                    { 2, "20 Burnout Close", null, "United Kingdom", new DateTime(2002, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "benchadwick@ptwise.com", "Ben", "PT Wise Gym", "Chadwick", "WR14 1KT", "07496327386", "Mr" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "Country", "DateOfBirth", "Email", "FirstName", "LastName", "Postcode", "TelephoneNumber", "Title", "TrainerId" },
                values: new object[,]
                {
                    { 1, "100 Elgar Road", null, "United Kingdom", new DateTime(2003, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "kacermarciniak@gmail.com", "Kacper", "Marciniak", "WR14 3EZ", "07465321286", "Mr", 1 },
                    { 2, "25 Oak Street", null, "United Kingdom", new DateTime(1995, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily.johnson@example.com", "Emily", "Johnson", "AB12 3CD", "07894561234", "Ms", 2 },
                    { 3, "15 Maple Avenue", null, "United Kingdom", new DateTime(1988, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "sophia.garcia@example.com", "Sophia", "Garcia", "XY34 9AB", "07123456789", "Mrs", 1 },
                    { 4, "7 Pine Street", null, "United Kingdom", new DateTime(1990, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniel.smith@example.com", "Daniel", "Smith", "CD56 8EF", "07654321098", "Mr", 2 },
                    { 5, "30 Elm Road", null, "United Kingdom", new DateTime(2001, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "isabella.brown@example.com", "Isabella", "Brown", "EF67 2GH", "07987654321", "Miss", 1 },
                    { 6, "12 Birch Lane", null, "United Kingdom", new DateTime(1985, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "oliver.davis@example.com", "Oliver", "Davis", "GH45 1IJ", "07234567890", "Mr", 2 }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "ClientId", "ClientId1", "EndTime", "StartTime", "Status", "Title", "TrainerId", "TrainerId1" },
                values: new object[,]
                {
                    { 1, 6, null, new DateTime(2023, 11, 28, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 28, 12, 30, 0, 0, DateTimeKind.Unspecified), 0, "Session 1", 1, null },
                    { 2, 5, null, new DateTime(2023, 11, 28, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 28, 15, 0, 0, 0, DateTimeKind.Unspecified), 2, "Session 2", 1, null },
                    { 3, 4, null, new DateTime(2023, 11, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, "Session 3", 1, null },
                    { 4, 2, null, new DateTime(2023, 12, 5, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), 3, "Session 4", 2, null }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "AppointmentId", "Date", "DurationMins", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 5, 19, 39, 54, 684, DateTimeKind.Local).AddTicks(927), 60, "Bombaclaat Belly Blast" },
                    { 2, 2, new DateTime(2023, 12, 5, 19, 39, 54, 684, DateTimeKind.Local).AddTicks(973), 60, "Marcin's Muscle Maker" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Difficulty", "ExerciseType", "Name", "Reps", "RestPeriodSeconds", "Sets", "WorkoutId" },
                values: new object[,]
                {
                    { 1, 0, 2, "Bench Press", "6", 90, 4, 1 },
                    { 2, 0, 2, "Tricep Extensions", "8", 60, 5, 1 },
                    { 3, 1, 2, "Squat", "8", 120, 4, 2 },
                    { 4, 2, 2, "Deadlift", "6", 120, 4, 2 },
                    { 5, 1, 2, "Pull-ups", "10", 60, 3, 1 },
                    { 6, 1, 2, "Shoulder Press", "8", 90, 4, 1 },
                    { 7, 0, 2, "Bicep Curls", "10", 45, 3, 2 },
                    { 8, 1, 2, "Lunges", "12", 60, 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ClientId",
                table: "Appointments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ClientId1",
                table: "Appointments",
                column: "ClientId1");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TrainerId",
                table: "Appointments",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TrainerId1",
                table: "Appointments",
                column: "TrainerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TrainerId",
                table: "Clients",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_WorkoutId",
                table: "Exercises",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_AppointmentId",
                table: "Workouts",
                column: "AppointmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastLoginDateTime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");
        }
    }
}
