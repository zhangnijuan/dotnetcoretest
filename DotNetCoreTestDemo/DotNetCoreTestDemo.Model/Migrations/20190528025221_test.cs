using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreTestDemo.Model.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(type: "NVARCHAR", maxLength: 16, nullable: false),
                    PassWord = table.Column<string>(type: "NVARCHAR", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR", maxLength: 8, nullable: false),
                    Phone = table.Column<string>(type: "VARCHAR", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
