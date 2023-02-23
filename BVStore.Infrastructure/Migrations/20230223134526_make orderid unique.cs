using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BVStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class makeorderidunique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex("UniqueOrder", "Orders", "OrderId", unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
