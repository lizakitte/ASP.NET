using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace lab3_car.Models

//W każdym modelu należy zadeklarować jedną wspólną właściwość Id typu int.
//Nad właściwością umieść atrybut [HiddenInput].
//Car - model, producent, pojemność silnika, moc, rodzaj silnika, nr rejestracyjny, właściciel
{
    public class Car
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Musisz podac model")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Musisz podac producenta")]
        public string Manufacturer { get; set; }
        public decimal? Capaciy { get; set; }
        public decimal? Power { get; set; }
        public string? EngineType { get; set; }
        [Required(ErrorMessage = "Musisz podac nr rejestracyjny")]
        public int RegistratioinNumber { get; set; }
        [StringLength(maximumLength: 50, ErrorMessage = "Zbyt dlugie imie, podaj mniejsze")]
        public string? Owner { get; set; }
    }
}
