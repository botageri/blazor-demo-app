using System.ComponentModel.DataAnnotations;

namespace BlazorDemoUI.Data.SignIn;

public class SignInUser
{
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}
