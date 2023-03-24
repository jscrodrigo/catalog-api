using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogApi.Migrations
{
    /// <inheritdoc />
    public partial class AddProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                $@"INSERT INTO PRODUCTS(
                                        NAME, 
                                        DESCRIPTION, 
                                        PRICE, 
                                        IMAGEURL, 
                                        AMOUNT, 
                                        REGISTERDATE,
                                        CATEGORYID)
                                VALUES(
                                        'Tuna Sandwich',
                                        'A delicious sandwich made with tuna, tomatoes and olive oil',
                                        7.50,
                                        'sw_tuna-tomatoes.jpg',
                                        15,
                                        NOW(),
                                        1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM PRODUCTS");
        }
    }
}
