using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreTestDemo.Model.Migrations
{
    public partial class test6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "UserInfo",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "PassWord",
                table: "UserInfo",
                maxLength: 24,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar",
                oldMaxLength: 24);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserInfo",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar",
                oldMaxLength: 8);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "UserInfo",
                type: "varchar",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "PassWord",
                table: "UserInfo",
                type: "nvarchar",
                maxLength: 24,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 24);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserInfo",
                type: "nvarchar",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 8);
        }
    }
}
