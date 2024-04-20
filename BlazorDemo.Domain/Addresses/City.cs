using BlazorDemo.Domain.Primitives;
using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Domain.Addresses;

public record City
{
    public City() { }
    public City(string postCode, string name) 
    { 
        PostCode = postCode; 
        Name = name; 
    }

    [Required]
    public string PostCode { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;
}
