using LabMovieStore.Data;
using MovieStore.Contracts;
using MovieStore.Models;

namespace MovieStore.Services;

public class InMemoryMovieService : IMovieService
{
    private readonly IList<Movie> _movies = Seed.Movies.ToList();

    public IList<Movie> GetMovies()
    {
        return _movies;
    }

    public Movie? GetById(int id)
    {
        return _movies.FirstOrDefault(m => m.Id == id);
    }

    public void AddMovie(Movie movie)
    {
        movie.Id = _movies.Max(m => m.Id) + 1;
        _movies.Add(movie);
    }

    public void UpdateMovie(Movie movie)
    {
        _movies.Remove(movie);
        _movies.Add(movie);
    }

    public void RemoveMovie(Movie movie)
    {
        _movies.Remove(movie);
    }
}
