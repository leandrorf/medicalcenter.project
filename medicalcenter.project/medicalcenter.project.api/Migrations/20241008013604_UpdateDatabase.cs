using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medicalcenter.project.api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.AlterColumn<int>(
                name: "Sexo",
                table: "Pacientes",
                type: "int",
                nullable: false,
                oldClrType: typeof( string ),
                oldType: "nvarchar(max)" );
        }

        /// <inheritdoc />
        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof( int ),
                oldType: "int" );
        }
    }
}