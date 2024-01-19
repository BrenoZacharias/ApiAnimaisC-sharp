using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAnimais.Migrations
{
    /// <inheritdoc />
    public partial class AnimaisMigracao2alterandoModelAnimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "animais");

            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "animais",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "animais");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DataNascimento",
                table: "animais",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
