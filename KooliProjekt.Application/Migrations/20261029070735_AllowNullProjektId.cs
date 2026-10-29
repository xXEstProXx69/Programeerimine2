using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KooliProjekt.Application.Migrations
{
    /// <inheritdoc />
    public partial class AllowNullProjektId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projekts_ProjektId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "ProjektId",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projekts_ProjektId",
                table: "Tasks",
                column: "ProjektId",
                principalTable: "Projekts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projekts_ProjektId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "ProjektId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projekts_ProjektId",
                table: "Tasks",
                column: "ProjektId",
                principalTable: "Projekts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
