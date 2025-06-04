using LabMovieStore.Data;
using MovieStore.Contracts;
using MovieStore.Models;

namespace MovieStore.Services;

public class CinemaService : ICinemaService
{
    private readonly MovieDbContext _context;

    public CinemaService(MovieDbContext context)
    {
        _context = context;
    }

    public Cinema? GetById(int id)
    {
        return _context.Cinemas.FirstOrDefault(m => m.Id == id);
    }

    public IList<Cinema> GetCinemas()
    {
        return _context.Cinemas.ToList();
    }

    public void AddCinema(Cinema movie)
    {
        _context.Cinemas.Add(movie);
        _context.SaveChanges();
    }

    public void RemoveCinema(Cinema movie)
    {
        _context.Cinemas.Remove(movie);
        _context.SaveChanges();
    }

    public void UpdateCinema(Cinema movie)
    {
        _context.Cinemas.Update(movie);
        _context.SaveChanges();
    }
}
