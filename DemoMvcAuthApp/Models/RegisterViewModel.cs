using System.ComponentModel.DataAnnotations;

namespace DemoMvcApp.Models;

public class RegisterViewModel
{
    [Required]
    public required string Username { get; set; }

    [Required, EmailAddress]
    public required string Email { get; set; }

    [Required, DataType(DataType.Password)]
    public required string Password { get; set; }

    [Required, DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Die Passwörter stimmen nicht überein")]
    public required string ConfirmPassword { get; set; }
}