using BlazorDemo.Domain.Addresses;
using BlazorDemo.Domain.Users;
using System.ComponentModel.DataAnnotations;

namespace UserManagerMVC.Models.Users;

public class EditUserViewModel
{
    [Display(Name = "Keresztnév*")]
    [Required(ErrorMessage = "Adja meg a keresztnevet!")]

    public string FirstName { get; set; } = string.Empty;

    [Display(Name = "Vezetéknév*")]
    [Required(ErrorMessage = "Adja meg a vezetéknevet!")]
    public string LastName { get; set; } = string.Empty;

    [Display(Name = "Város*")]
    [Required(ErrorMessage = "Válasszon ki egy várost!")]
    [DataType(DataType.PostalCode)]
    public string PostCode { get; set; }

    [Display(Name = "Cím*")]
    [Required(ErrorMessage = "Adjon meg egy címet!")]
    public string Address { get; set; } = string.Empty;

    [Display(Name = "E-mail cím*")]
    [Required(ErrorMessage = "Adjon meg egy e-mail címet!")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Jelszó*")]
    [Required(ErrorMessage = "Adjon meg egy jelszót!")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "Születési év*")]
    [Required(ErrorMessage = "Adja meg a születési évét!")]
    public DateTime BirthDate { get; set; } = new DateTime(2000, 1, 1);

    [Display(Name = "Születési hely*")]
    [Required(ErrorMessage = "Adja meg a születési helyét!")]
    public string BirthPlace { get; set; } = string.Empty;

    [Display(Name = "Telefonszám*")]
    [Required(ErrorMessage = "Adja meg a születési helyét!")]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; } = string.Empty;

    [Microsoft.AspNetCore.Mvc.HiddenInput]
    public int Id { get; set; }

    public EditUserViewModel()
    {
        
    }

    public EditUserViewModel(User user)
    {
        Id = user.Id;
        FirstName = user.FirstName;
        LastName = user.LastName;
        PostCode = user.City.PostCode;
        Address = user.Address;
        Email = user.Email;
        Password = user.Password;
        BirthDate = user.BirthDate;
        BirthPlace = user.BirthPlace;
        PhoneNumber = user.PhoneNumber;
    }

    public User ToUser(City city)
    {
        return new User()
        {
            Id = Id,
            FirstName = FirstName,
            LastName = LastName,
            City = city,
            Address = Address,
            Email = Email,
            Password = Password,
            BirthDate = BirthDate,
            BirthPlace = BirthPlace,
            PhoneNumber = PhoneNumber,
        };
    }
}
