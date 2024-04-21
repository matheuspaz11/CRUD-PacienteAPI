using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_PacienteAPI.Migrations
{
    public partial class UpdateDateBirthColumnType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateBirth",
                table: "tb_patient",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateBirth",
                table: "tb_patient",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)");
        }
    }
}
