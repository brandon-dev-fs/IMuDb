using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAlbumDB.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Columns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Members",
                table: "Artists",
                newName: "Musicians");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtistId",
                table: "Songs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueIdentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AlbumId",
                table: "Songs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueIdentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Songs",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueIdentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Artists",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueIdentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtistId",
                table: "Albums",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueIdentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Albums",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueIdentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Musicians",
                table: "Artists",
                newName: "Members");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtistId",
                table: "Songs",
                type: "uniqueIdentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AlbumId",
                table: "Songs",
                type: "uniqueIdentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Songs",
                type: "uniqueIdentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Artists",
                type: "uniqueIdentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtistId",
                table: "Albums",
                type: "uniqueIdentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Albums",
                type: "uniqueIdentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
