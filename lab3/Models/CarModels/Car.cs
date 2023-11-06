using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace lab3_App.Models.CarModels

//W każdym modelu należy zadeklarować jedną wspólną właściwość Id typu int.
//Nad właściwością umieść atrybut [HiddenInput].
//Car - model, producent, pojemność silnika, moc, rodzaj silnika, nr rejestracyjny, właściciel
{
    public enum Engine
    {
        [Display(Name = "Benzynowy")]
        Gasoline,
        [Display(Name = "Diesel")]
        Diesel,
        [Display(Name = "LPG")]
        LPG,
        [Display(Name = "Hybrydowy")]
        Hybrid
    }

    public class Car
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Model")]
        [Required(ErrorMessage = "Musisz podac model")]
        public string Model { get; set; }

        [Display(Name = "Producent")]
        [Required(ErrorMessage = "Musisz podac producenta")]
        public string Manufacturer { get; set; }

        [Display(Name = "Pojemnosc silnika")]
        public decimal? Capaciy { get; set; }

        [Display(Name = "Moc")]
        public decimal? Power { get; set; }

        [Display(Name = "Rodzaj silnika")]
        public Engine EngineType { get; set; }

        [Display(Name = "Nr rejestracyjny")]
        [Required(ErrorMessage = "Musisz podac nr rejestracyjny")]
        public int RegistratioinNumber { get; set; }

        [Display(Name = "Wlasciciel")]
        [StringLength(maximumLength: 50, ErrorMessage = "Zbyt dlugie imie, podaj mniejsze")]
        public string? Owner { get; set; }
    }
}
