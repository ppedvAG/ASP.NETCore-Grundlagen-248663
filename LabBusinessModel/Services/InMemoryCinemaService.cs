using LabMovieStore.Data;
using MovieStore.Contracts;
using MovieStore.Models;

namespace MovieStore.Services;

public class InMemoryCinemaService : ICinemaService
{
    private readonly IList<Cinema> _cinemas = Seed.Cinemas.ToList(); // Kopie von der Liste


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
