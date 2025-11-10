using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitHero.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateHabitEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habits_Users_UserId",
                table: "Habits");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Habits",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Habits",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Frequency",
                table: "Habits",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Habits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Habits",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Habits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Habits_Users_UserId",
                table: "Habits",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habits_Users_UserId",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Habits");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Habits",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Habits_Users_UserId",
                table: "Habits",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
