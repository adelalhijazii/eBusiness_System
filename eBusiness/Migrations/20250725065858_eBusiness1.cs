using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBusiness.Migrations
{
    /// <inheritdoc />
    public partial class eBusiness1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MasterAdvancedCapabilitiesIcon",
                table: "MasterAdvancedCapabilities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterAdvancedCapabilitiesIcon",
                table: "MasterAdvancedCapabilities");
        }
    }
}
