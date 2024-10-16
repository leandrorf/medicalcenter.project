﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medicalcenter.project.api.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<Guid>( type: "uniqueidentifier", nullable: false ),
                    Nome = table.Column<string>( type: "nvarchar(max)", nullable: false ),
                    Descricao = table.Column<string>( type: "nvarchar(max)", nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_Especialidades", x => x.Id );
                } );

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<Guid>( type: "uniqueidentifier", nullable: false ),
                    Nome = table.Column<string>( type: "nvarchar(max)", nullable: false ),
                    Telefone = table.Column<string>( type: "nvarchar(max)", nullable: false ),
                    Sexo = table.Column<string>( type: "nvarchar(max)", nullable: false ),
                    Email = table.Column<string>( type: "nvarchar(max)", nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_Pacientes", x => x.Id );
                } );

            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    Id = table.Column<Guid>( type: "uniqueidentifier", nullable: false ),
                    PacienteId = table.Column<Guid>( type: "uniqueidentifier", nullable: false ),
                    NumeroSequencial = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    DataHoraChegada = table.Column<DateTime>( type: "datetime2", nullable: false ),
                    Status = table.Column<int>( type: "int", nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_Atendimentos", x => x.Id );
                    table.ForeignKey(
                        name: "FK_Atendimentos_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade );
                } );

            migrationBuilder.CreateTable(
                name: "Triagens",
                columns: table => new
                {
                    Id = table.Column<Guid>( type: "uniqueidentifier", nullable: false ),
                    AtendimentoId = table.Column<Guid>( type: "uniqueidentifier", nullable: false ),
                    EspecialidadeId = table.Column<Guid>( type: "uniqueidentifier", nullable: false ),
                    Sintomas = table.Column<string>( type: "nvarchar(max)", nullable: false ),
                    PressaoArterial = table.Column<string>( type: "nvarchar(max)", nullable: false ),
                    Peso = table.Column<double>( type: "float", nullable: false ),
                    Altura = table.Column<double>( type: "float", nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_Triagens", x => x.Id );
                    table.ForeignKey(
                        name: "FK_Triagens_Atendimentos_AtendimentoId",
                        column: x => x.AtendimentoId,
                        principalTable: "Atendimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade );
                    table.ForeignKey(
                        name: "FK_Triagens_Especialidades_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade );
                } );

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_PacienteId",
                table: "Atendimentos",
                column: "PacienteId" );

            migrationBuilder.CreateIndex(
                name: "IX_Triagens_AtendimentoId",
                table: "Triagens",
                column: "AtendimentoId" );

            migrationBuilder.CreateIndex(
                name: "IX_Triagens_EspecialidadeId",
                table: "Triagens",
                column: "EspecialidadeId" );
        }

        /// <inheritdoc />
        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.DropTable(
                name: "Triagens" );

            migrationBuilder.DropTable(
                name: "Atendimentos" );

            migrationBuilder.DropTable(
                name: "Especialidades" );

            migrationBuilder.DropTable(
                name: "Pacientes" );
        }
    }
}