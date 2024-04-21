using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_PacienteAPI.Migrations
{
    public partial class UpdateDateBirth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateBirth",
                table: "tb_patient",
                type: "text",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateBirth",
                table: "tb_patient",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
