using BlazorDemo.Domain.Addresses;
using BlazorDemo.Domain.Users;
using System.ComponentModel.DataAnnotations;

namespace UserManagerMVC.Models.Users;

public class UserViewModel
{
    [Display(Name = "Keresztnév")]
    public string FirstName { get; set; } = string.Empty;

    [Display(Name = "Vezetéknév")]
    public string LastName { get; set; } = string.Empty;

    [Display(Name = "Irányítószám")]
    public string PostCode { get; set; }

    [Display(Name = "Város")]
    public string City { get; set; }

    [Display(Name = "Cím")]
    public string Address { get; set; } = string.Empty;

    [Display(Name = "E-mail cím")]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Jelszó")]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "Születési év")]
    public string BirthDate { get; set; } = string.Empty;

    [Display(Name = "Születési hely")]
    public string BirthPlace { get; set; } = string.Empty;

    [Display(Name = "Telefonszám")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Display(Name = "Id")]
    public string Id { get; set; } = string.Empty;

    public UserViewModel()
    {
        
    }

    public UserViewModel(User user)
    {
        Id = user.Id.ToString();
        FirstName = user.FirstName;
        LastName = user.LastName;
        PostCode = user.City.PostCode;
        City = user.City.Name;
        Address = user.Address;
        Email = user.Email;
        Password = user.Password;
        BirthDate = user.BirthDate.ToString("yyyy.MM.dd");
        BirthPlace = user.BirthPlace;
        PhoneNumber = user.PhoneNumber;
    }
}