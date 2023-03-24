using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var registerDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            migrationBuilder.Sql($"INSERT INTO CATEGORIES(NAME, REGISTERDATE) VALUES('Food', '{registerDate}')");
            migrationBuilder.Sql($"INSERT INTO CATEGORIES(NAME, REGISTERDATE) VALUES('Beverage', '{registerDate}')");
            migrationBuilder.Sql($"INSERT INTO CATEGORIES(NAME, REGISTERDATE) VALUES('Dessert', '{registerDate}')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM CATEGORIES");
        }
    }
}
