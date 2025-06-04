using Microsoft.EntityFrameworkCore;
using MovieStore.Models;

namespace LabMovieStore.Data;

public class MovieDbContext : DbContext
{
    public DbSet<Cinema> Cinemas { get; set; }

    public DbSet<Movie> Movies { get; set; }

    public MovieDbContext(DbContextOptions<MovieDbContext> options) 
        : base(options)
    {        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cinema>().HasData(Seed.Cinemas);
        modelBuilder.Entity<Movie>().HasData(Seed.Movies);

        // Fix warning for Price precision
        modelBuilder.Entity<Movie>().Property(m => m.Price).HasPrecision(5, 2);
    }
}
