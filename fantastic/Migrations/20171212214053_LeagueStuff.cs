using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace fantastic.Migrations
{
    public partial class LeagueStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "losses",
                table: "teams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ties",
                table: "teams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "wins",
                table: "teams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LeagueId",
                table: "athletes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "athletes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "assist",
                table: "athletes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "assts",
                table: "athletes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "error",
                table: "athletes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "goal",
                table: "athletes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "hits",
                table: "athletes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "hr",
                table: "athletes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "pts",
                table: "athletes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "rbi",
                table: "athletes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "rebs",
                table: "athletes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "runs",
                table: "athletes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "td",
                table: "athletes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "to",
                table: "athletes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_athletes_LeagueId",
                table: "athletes",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_athletes_TeamId",
                table: "athletes",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_athletes_leagues_LeagueId",
                table: "athletes",
                column: "LeagueId",
                principalTable: "leagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_athletes_teams_TeamId",
                table: "athletes",
                column: "TeamId",
                principalTable: "teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_athletes_leagues_LeagueId",
                table: "athletes");

            migrationBuilder.DropForeignKey(
                name: "FK_athletes_teams_TeamId",
                table: "athletes");

            migrationBuilder.DropIndex(
                name: "IX_athletes_LeagueId",
                table: "athletes");

            migrationBuilder.DropIndex(
                name: "IX_athletes_TeamId",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "losses",
                table: "teams");

            migrationBuilder.DropColumn(
                name: "ties",
                table: "teams");

            migrationBuilder.DropColumn(
                name: "wins",
                table: "teams");

            migrationBuilder.DropColumn(
                name: "LeagueId",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "assist",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "assts",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "error",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "goal",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "hits",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "hr",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "pts",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "rbi",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "rebs",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "runs",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "td",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "to",
                table: "athletes");
        }
    }
}
