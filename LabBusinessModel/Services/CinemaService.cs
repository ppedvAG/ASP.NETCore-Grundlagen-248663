using MovieStore.Contracts;
using MovieStore.Models;

namespace MovieStore.Services;

public class CinemaService : ICinemaService
{
    private readonly IList<Cinema> _cinemas =
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

    public IList<Cinema> GetCinemas()
    {
        return _cinemas;
    }

    public Cinema? GetById(int id)
    {
        return _cinemas.FirstOrDefault(c => c.Id == id);
    }

    public void AddCinema(Cinema cinema)
    {
        cinema.Id = _cinemas.Max(c => c.Id) + 1;
        _cinemas.Add(cinema);
    }

    public void UpdateCinema(Cinema cinema)
    {
        var existing = _cinemas.FirstOrDefault(c => c.Id == cinema.Id);
        if (existing != null)
        {
            _cinemas.Remove(existing);
            _cinemas.Add(cinema);
        }
    }

    public void RemoveCinema(Cinema cinema)
    {
        _cinemas.Remove(cinema);
    }
}
