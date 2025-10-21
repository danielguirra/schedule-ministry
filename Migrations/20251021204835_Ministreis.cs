using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEscala.Migrations
{
    /// <inheritdoc />
    public partial class Ministreis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ministries_Members_CoordinatorId",
                table: "Ministries");

            migrationBuilder.DropIndex(
                name: "IX_Ministries_CoordinatorId",
                table: "Ministries");

            migrationBuilder.DropColumn(
                name: "CoordinatorId",
                table: "Ministries");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ministries",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Ministries",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<List<Guid>>(
                name: "CoordinatorsId",
                table: "Ministries",
                type: "uuid[]",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoordinatorsId",
                table: "Ministries");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ministries",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Ministries",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CoordinatorId",
                table: "Ministries",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Ministries_CoordinatorId",
                table: "Ministries",
                column: "CoordinatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ministries_Members_CoordinatorId",
                table: "Ministries",
                column: "CoordinatorId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
