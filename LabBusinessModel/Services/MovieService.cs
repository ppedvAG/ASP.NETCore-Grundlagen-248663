using LabMovieStore.Data;
using MovieStore.Contracts;
using MovieStore.Models;

namespace MovieStore.Services;

// TODO sollte das async / await Pattern haben
public class MovieService : IMovieService
{
    private readonly MovieDbContext _context;

    public MovieService(MovieDbContext context)
    {
        _context = context;
    }

    public Movie? GetById(int id)
    {
        return _context.Movies.FirstOrDefault(m => m.Id == id);
    }

    public IList<Movie> GetMovies()
    {
        return _context.Movies.ToList();
    }

    public void AddMovie(Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();
    }

    public void RemoveMovie(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
    }

    public void UpdateMovie(Movie movie)
    {
        _context.Movies.Update(movie);
        _context.SaveChanges();
    }
}
