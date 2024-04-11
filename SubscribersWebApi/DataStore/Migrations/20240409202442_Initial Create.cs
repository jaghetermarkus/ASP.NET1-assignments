﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    DailyNewsletter = table.Column<bool>(type: "INTEGER", nullable: false),
                    AdvertisingUpdates = table.Column<bool>(type: "INTEGER", nullable: false),
                    WeekinReview = table.Column<bool>(type: "INTEGER", nullable: false),
                    EventUpdates = table.Column<bool>(type: "INTEGER", nullable: false),
                    StartupsWeekly = table.Column<bool>(type: "INTEGER", nullable: false),
                    Podcasts = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Email);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscribers");
        }
    }
}
