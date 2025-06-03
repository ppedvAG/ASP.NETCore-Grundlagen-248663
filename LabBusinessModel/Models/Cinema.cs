using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models;

public class Cinema
{
    public long Id { get; set; }
    public string Name { get; set; }

    [Display(Name = "Straße")]
    public string Address { get; set; }

    [Display(Name = "Stadt")]
    public string City { get; set; }

    [Display(Name = "Beschreibung"), DisplayFormat(NullDisplayText = "Keine Beschreibung vorhanden")]
    public string Description { get; set; }

    [Display(Name = "Räume")]
    public int NumberOfHalls { get; set; }

    [Display(Name = "Sitzplätze")]
    public int TotalSeats { get; set; }

    [Display(Name = "Telefon")]
    public string PhoneNumber { get; set; }

    [Display(Name = "Website")]
    public string WebsiteUrl { get; set; }

    [Display(Name = "Bild")]
    public string ImageUrl { get; set; }
}