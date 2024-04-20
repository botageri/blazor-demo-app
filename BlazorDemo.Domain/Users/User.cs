using BlazorDemo.Domain.Addresses;
using BlazorDemo.Domain.Primitives;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorDemo.Domain.Users;

/// <summary>
/// Anemic domain model for user
/// </summary>
public class User : Entity
{
    [Display(Name = "Keresztnév*")]
    [Required(ErrorMessage = "Adja meg a keresztnevet!")]
    public string FirstName { get; set; } = string.Empty;

    [Display(Name = "Vezetéknév*")]
    [Required(ErrorMessage = "Adja meg a vezetéknevet!")]
    public string LastName { get; set; } = string.Empty;

    [Display(Name = "Város*")]
    [Required(ErrorMessage = "Válasszon ki egy várost!")]
    public City City { get; set; }

    [Display(Name = "Cím*")]
    [Required(ErrorMessage = "Adjon meg egy címet!")]
    public string Address { get; set; } = string.Empty;

    [Display(Name = "E-mail cím*")]
    [Required(ErrorMessage = "Adjon meg egy e-mail címet!")]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Jelszó*")]
    [Required(ErrorMessage = "Adjon meg egy jelszót!")]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "Születési év*")]
    [Required(ErrorMessage = "Adja meg a születési évét!")]
    public DateTime BirthDate { get; set; } = new DateTime(2000,1,1);

    [Display(Name = "Születési hely*")]
    [Required(ErrorMessage = "Adja meg a születési helyét!")]
    public string BirthPlace { get; set; } = string.Empty;
}
