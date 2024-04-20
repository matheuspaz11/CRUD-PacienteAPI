using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_PacienteAPI.Migrations
{
    public partial class UpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estate",
                table: "tb_address",
                newName: "State");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State",
                table: "tb_address",
                newName: "Estate");
        }
    }
}
