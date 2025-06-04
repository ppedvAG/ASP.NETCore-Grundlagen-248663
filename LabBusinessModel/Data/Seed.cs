using MovieStore.Models;

namespace LabMovieStore.Data;

public class Seed
{
    public static List<Cinema> Cinemas =>
    [
        new Cinema
        {
            Id = 1,
            Name = "Cinema Paradiso",
            Address = "Musterstraße 1",
            City = "Berlin",
            Description = "Modernes Kino mit 8 Sälen, 3D-Technik und Lounge-Bereich.",
            NumberOfHalls = 8,
            TotalSeats = 1200,
            PhoneNumber = "030-12345678",
            WebsiteUrl = "https://www.cinema-paradiso.de",
            ImageUrl = "https://www.cinema-paradiso.de/Cinema_Paradiso.jpg"
        },
        new Cinema
        {
            Id = 2,
            Name = "Filmtheater Stern",
            Address = "Hauptstraße 99",
            City = "Hamburg",
            Description = "Traditionsreiches Programmkino mit besonderem Flair.",
            NumberOfHalls = 3,
            TotalSeats = 350,
            PhoneNumber = "040-98765432",
            WebsiteUrl = "https://www.filmtheater-stern.de",
            ImageUrl = "https://www.filmtheater-stern.de/Filmtheater_Stern.jpg"
        },
        new Cinema
        {
            Id = 3,
            Name = "Lichtspielhaus am See",
            Address = "Seepromenade 10",
            City = "München",
            Description = "Kino direkt am Wasser mit Open-Air-Veranstaltungen im Sommer.",
            NumberOfHalls = 5,
            TotalSeats = 700,
            PhoneNumber = "089-24681012",
            WebsiteUrl = "https://www.lichtspielhaus-am-see.de",
            ImageUrl = "https://www.lichtspielhaus-am-see.de/Lichtspielhaus_am_See.jpg"
        }
    ];

    public static List<Movie> Movies =>
    [
        new Movie
        {
            Id = 1,
            Title = "Die Verurteilten (The Shawshank Redemption)",
            Description = "Erzählt die Geschichte von Andy Dufresne, einem Banker, der fälschlicherweise wegen Mordes an seiner Frau und deren Liebhaber verurteilt wird und im Gefängnis Freundschaft mit einem Mitgefangenen namens Red schließt, während er über Jahrzehnte hinweg an einem Fluchtplan arbeitet.",
            Genre = MovieGenre.Drama,
            Price = 13.99m,
            PublishedDate = new DateTime(1994, 10, 14),
            IMDBRating = 8.5,
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/81/ShawshankRedemptionMoviePoster.jpg"
        },
        new Movie
        {
            Id = 2,
            Title = "Der Pate (The Godfather)",
            Description = "Erzählt die Geschichte der Corleone-Familie, die von einem Mafia-Patriarchen geführt wird, und die Machtkämpfe und familiären Konflikte, die entstehen, als sein Sohn die Kontrolle übernimmt.",
            Genre = MovieGenre.Drama,
            Price = 19.99m,
            PublishedDate = new DateTime(1972, 3, 24),
            IMDBRating = 7.6,
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/1c/Godfather_ver1.jpg"
        },
        new Movie
        {
            Id = 3,
            Title = "Jurassic Park",
            Description = "Handelt von einem Themenpark mit geklonten Dinosauriern, der von Wissenschaftlern und Besuchern erkundet wird, bis ein Sabotageakt die Sicherheitssysteme außer Kraft setzt und die Dinosaurier freilässt, was zu einer gefährlichen Flucht ums Überleben führt.",
            Genre = MovieGenre.Adventure,
            Price = 12.99m,
            PublishedDate = new DateTime(1993, 11, 8),
            IMDBRating = 9,
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e7/Jurassic_Park_poster.jpg"
        }
    ];
}