using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreTestDemo.Model.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserInfo",
                type: "nvarchar",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR",
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "UserInfo",
                type: "varchar",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "PassWord",
                table: "UserInfo",
                type: "nvarchar",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR",
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserInfo",
                type: "nvarchar",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR",
                oldMaxLength: 8);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserInfo",
                type: "NVARCHAR",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar",
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "UserInfo",
                type: "VARCHAR",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "PassWord",
                table: "UserInfo",
                type: "NVARCHAR",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar",
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserInfo",
                type: "NVARCHAR",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar",
                oldMaxLength: 8);
        }
    }
}
