using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace lab3_App.Models
{
    public class Contact
    {
    [HiddenInput]
    public int Id { get; set; }
    [Required(ErrorMessage = "Musisz podac imie")]
    [StringLength(maximumLength: 50, ErrorMessage = "Zbyt dlugie imie, podaj mniejsze")]
    public string Name { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Phone]
    public string Phone { get; set; }
    public DateTime? Birth { get; set; }
    }
}
