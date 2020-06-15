using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipe.DataAccess.Migrations
{
    public partial class UpdateREcipeIngredientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "RecipeIngredients",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "RecipeIngredients",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "RecipeIngredients");
        }
    }
}
