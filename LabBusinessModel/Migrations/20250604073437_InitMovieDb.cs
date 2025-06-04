﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LabMovieStore.Migrations
{
    /// <inheritdoc />
    public partial class InitMovieDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfHalls = table.Column<int>(type: "int", nullable: false),
                    TotalSeats = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IMDBRating = table.Column<double>(type: "float", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Address", "City", "Description", "ImageUrl", "Name", "NumberOfHalls", "PhoneNumber", "TotalSeats", "WebsiteUrl" },
                values: new object[,]
                {
                    { 1L, "Musterstraße 1", "Berlin", "Modernes Kino mit 8 Sälen, 3D-Technik und Lounge-Bereich.", "https://www.cinema-paradiso.de/Cinema_Paradiso.jpg", "Cinema Paradiso", 8, "030-12345678", 1200, "https://www.cinema-paradiso.de" },
                    { 2L, "Hauptstraße 99", "Hamburg", "Traditionsreiches Programmkino mit besonderem Flair.", "https://www.filmtheater-stern.de/Filmtheater_Stern.jpg", "Filmtheater Stern", 3, "040-98765432", 350, "https://www.filmtheater-stern.de" },
                    { 3L, "Seepromenade 10", "München", "Kino direkt am Wasser mit Open-Air-Veranstaltungen im Sommer.", "https://www.lichtspielhaus-am-see.de/Lichtspielhaus_am_See.jpg", "Lichtspielhaus am See", 5, "089-24681012", 700, "https://www.lichtspielhaus-am-see.de" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Genre", "IMDBRating", "ImageUrl", "Price", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, "Erzählt die Geschichte von Andy Dufresne, einem Banker, der fälschlicherweise wegen Mordes an seiner Frau und deren Liebhaber verurteilt wird und im Gefängnis Freundschaft mit einem Mitgefangenen namens Red schließt, während er über Jahrzehnte hinweg an einem Fluchtplan arbeitet.", 6, 8.5, "https://upload.wikimedia.org/wikipedia/en/8/81/ShawshankRedemptionMoviePoster.jpg", 13.99m, new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Die Verurteilten (The Shawshank Redemption)" },
                    { 2, "Erzählt die Geschichte der Corleone-Familie, die von einem Mafia-Patriarchen geführt wird, und die Machtkämpfe und familiären Konflikte, die entstehen, als sein Sohn die Kontrolle übernimmt.", 6, 7.5999999999999996, "https://upload.wikimedia.org/wikipedia/en/1/1c/Godfather_ver1.jpg", 19.99m, new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Der Pate (The Godfather)" },
                    { 3, "Handelt von einem Themenpark mit geklonten Dinosauriern, der von Wissenschaftlern und Besuchern erkundet wird, bis ein Sabotageakt die Sicherheitssysteme außer Kraft setzt und die Dinosaurier freilässt, was zu einer gefährlichen Flucht ums Überleben führt.", 1, 9.0, "https://upload.wikimedia.org/wikipedia/en/e/e7/Jurassic_Park_poster.jpg", 12.99m, new DateTime(1993, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jurassic Park" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
