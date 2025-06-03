using MovieStore.Models;

namespace MovieStore.Contracts
{
    public interface ICinemaService
    {
        void AddCinema(Cinema cinema);
        Cinema? GetById(int id);
        IList<Cinema> GetCinemas();
        void RemoveCinema(Cinema cinema);
        void UpdateCinema(Cinema cinema);
    }
}