using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitHero.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCompletePropsForHabit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Frequency",
                table: "Habits",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCompleted",
                table: "Habits",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Habits",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCompleted",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Habits");

            migrationBuilder.AlterColumn<int>(
                name: "Frequency",
                table: "Habits",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
