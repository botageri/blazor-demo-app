using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UserManagerMVC.Models.SignIn;

public class SignInUser
{
    [Required]
    [EmailAddress]
    [DisplayName("Email")]
    public string Email { get; set; } = string.Empty;
    [Required]
    [PasswordPropertyText]
    [DisplayName("Jelszó")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}
