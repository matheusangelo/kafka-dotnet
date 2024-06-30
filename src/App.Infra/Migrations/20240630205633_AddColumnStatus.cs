using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "STATUS",
                table: "MESSAGE",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "STATUS",
                table: "MESSAGE");
        }
    }
}
