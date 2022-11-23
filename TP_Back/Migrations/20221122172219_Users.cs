using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_Back.Migrations
{
    public partial class Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_People_PersonId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Things_ThingId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Description",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "People",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "People",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Loans",
                newName: "ReturnDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Things",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<int>(
                name: "ThingId",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Loans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Loans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_People_PersonId",
                table: "Loans",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Things_ThingId",
                table: "Loans",
                column: "ThingId",
                principalTable: "Things",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_People_PersonId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Things_ThingId",
                table: "Loans");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "People",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "People",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "ReturnDate",
                table: "Loans",
                newName: "CreateDate");

            migrationBuilder.AlterColumn<int>(
                name: "CreationDate",
                table: "Things",
                type: "int",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<int>(
                name: "ThingId",
                table: "Loans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Loans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Description",
                table: "Categories",
                column: "Description",
                unique: true,
                filter: "[Description] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_People_PersonId",
                table: "Loans",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Things_ThingId",
                table: "Loans",
                column: "ThingId",
                principalTable: "Things",
                principalColumn: "Id");
        }
    }
}
