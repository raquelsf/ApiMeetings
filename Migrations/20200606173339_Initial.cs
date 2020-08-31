using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiMeetings.Migrations
{
  public partial class Initial : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Rooms",
          columns: table => new
          {
            Id = table.Column<Guid>(nullable: false),
            Name = table.Column<string>(maxLength: 30, nullable: false),
            Description = table.Column<string>(maxLength: 100, nullable: false),
            Floor = table.Column<int>(nullable: false),
            MaxPeople = table.Column<int>(nullable: false),
            HasTV = table.Column<bool>(nullable: false),
            HasPainting = table.Column<bool>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Room", x => x.Id);
          });

      migrationBuilder.CreateTable(
         name: "Reservations",
         columns: table => new
         {
           Id = table.Column<Guid>(nullable: false),
           UserId = table.Column<Guid>(nullable: false),
           RoomId = table.Column<Guid>(nullable: false),
           DateInitial = table.Column<DateTime>(nullable: false),
           DateEnd = table.Column<DateTime>(nullable: false)
         },
         constraints: table =>
         {
           table.PrimaryKey("PK_Reservation", x => x.Id);
           table.PrimaryKey("PK_Reservation_User", x => x.UserId);
           table.PrimaryKey("PK_Reservation_Room", x => x.RoomId);
         });

      migrationBuilder.CreateTable(
         name: "users",
         columns: table => new
         {
           Id = table.Column<Guid>(nullable: false),
           Name = table.Column<string>(maxLength: 30, nullable: false),
         },
         constraints: table =>
         {
           table.PrimaryKey("PK_User", x => x.Id);
         });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Rooms");
      migrationBuilder.DropTable(
         name: "Reservations");
      migrationBuilder.DropTable(
         name: "Users");
    }
  }
}