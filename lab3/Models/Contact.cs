using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace lab3_App.Models
{
    public enum Priority
    {
        [Display(Name = "Niski")]
        Low,
        [Display(Name = "Normalny")]
        Normal,
        [Display(Name = "Pilny")]
        Urgent
    }

    public class Contact
    {
    [HiddenInput]
    public int Id { get; set; }

    [Display(Name="Imie")]
    [Required(ErrorMessage = "Musisz podac imie")]
    [StringLength(maximumLength: 50, ErrorMessage = "Zbyt dlugie imie, podaj mniejsze")]
    public string Name { get; set; }

    [EmailAddress]
    [Display(Name = "Adres email")]
    public string Email { get; set; }

    [Phone]
    [Display(Name = "Telefon")]
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }

    [Display(Name = "Data urodzenia")]
    [DataType(DataType.Date)]
    public DateTime? Birth { get; set; }

    [Display(Name = "Priorytet")]
    public Priority Priority { get; set; }

    [HiddenInput]
    public DateTime Created { get; set; }
    }
}
