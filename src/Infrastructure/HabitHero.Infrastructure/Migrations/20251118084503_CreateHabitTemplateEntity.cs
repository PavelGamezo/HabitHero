using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitHero.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateHabitTemplateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HabitTemplateId",
                table: "Habits",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Frequency = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Name" },
                values: new object[] { 18, "ManageTemplateHabits" });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 18, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Habits_HabitTemplateId",
                table: "Habits",
                column: "HabitTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Habits_Templates_HabitTemplateId",
                table: "Habits",
                column: "HabitTemplateId",
                principalTable: "Templates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habits_Templates_HabitTemplateId",
                table: "Habits");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DropIndex(
                name: "IX_Habits_HabitTemplateId",
                table: "Habits");

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 18, 1 });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DropColumn(
                name: "HabitTemplateId",
                table: "Habits");
        }
    }
}
