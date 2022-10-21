using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimuladorCampeonatoAPI.Migrations
{
    public partial class Seccond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataInscricao",
                table: "TimeCampeonatos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "FoiEliminado",
                table: "TimeCampeonatos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<short>(
                name: "PenaltisTotais",
                table: "TimeCampeonatos",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "PontuacaoTotal",
                table: "TimeCampeonatos",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeCampeonatos_Times_TimeId",
                table: "TimeCampeonatos",
                column: "TimeId",
                principalTable: "Times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeCampeonatos_Times_TimeId",
                table: "TimeCampeonatos");

            migrationBuilder.DropColumn(
                name: "DataInscricao",
                table: "TimeCampeonatos");

            migrationBuilder.DropColumn(
                name: "FoiEliminado",
                table: "TimeCampeonatos");

            migrationBuilder.DropColumn(
                name: "PenaltisTotais",
                table: "TimeCampeonatos");

            migrationBuilder.DropColumn(
                name: "PontuacaoTotal",
                table: "TimeCampeonatos");
        }
    }
}
