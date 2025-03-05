using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAlbumDB.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ArtistTypeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Artists",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Artists");
        }
    }
}
