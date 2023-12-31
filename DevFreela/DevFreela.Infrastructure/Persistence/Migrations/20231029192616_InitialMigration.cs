﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevFreela.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdFreelancer = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinishAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Project_tb_User_IdClient",
                        column: x => x.IdClient,
                        principalTable: "tb_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_Project_tb_User_IdFreelancer",
                        column: x => x.IdFreelancer,
                        principalTable: "tb_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_UserSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdSkill = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_UserSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_UserSkill_tb_User_IdSkill",
                        column: x => x.IdSkill,
                        principalTable: "tb_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_ProjectComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdProject = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ProjectComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_ProjectComment_tb_Project_IdProject",
                        column: x => x.IdProject,
                        principalTable: "tb_Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_ProjectComment_tb_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "tb_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Project_IdClient",
                table: "tb_Project",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Project_IdFreelancer",
                table: "tb_Project",
                column: "IdFreelancer");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ProjectComment_IdProject",
                table: "tb_ProjectComment",
                column: "IdProject");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ProjectComment_IdUser",
                table: "tb_ProjectComment",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_tb_UserSkill_IdSkill",
                table: "tb_UserSkill",
                column: "IdSkill");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_ProjectComment");

            migrationBuilder.DropTable(
                name: "tb_Skill");

            migrationBuilder.DropTable(
                name: "tb_UserSkill");

            migrationBuilder.DropTable(
                name: "tb_Project");

            migrationBuilder.DropTable(
                name: "tb_User");
        }
    }
}
