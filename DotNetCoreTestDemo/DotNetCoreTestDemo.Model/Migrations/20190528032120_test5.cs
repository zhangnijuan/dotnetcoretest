using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreTestDemo.Model.Migrations
{
    public partial class test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserInfo",
                maxLength: 24,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar",
                oldMaxLength: 24);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserInfo",
                type: "nvarchar",
                maxLength: 24,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 24);
        }
    }
}
