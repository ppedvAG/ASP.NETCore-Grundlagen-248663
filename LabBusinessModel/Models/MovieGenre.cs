using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models
{
    public enum MovieGenre
    {
        Action,
        [Display(Name = "Abenteuer")]
        Adventure,
        Animation,
        Classic,
        [Display(Name = "Komödie")]
        Comedy,
        [Display(Name = "Krimi")]
        Crime,
        Drama,
        Horror,
        Mystery,
        SciFi,
        Thriller
    }
}
