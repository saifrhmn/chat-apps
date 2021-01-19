using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityAndAuthorizationServer.Migrations
{
    public partial class apimigv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PublicChatMessages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicChatMessages_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PublicChatMessages_ApplicationUserId",
                table: "PublicChatMessages",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublicChatMessages");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");
        }
    }
}
