using Microsoft.AspNetCore.Identity;

namespace BusinessModel.Models;

public class AppUser : IdentityUser
{
    public string? FavoriteDish { get; set; }
}
