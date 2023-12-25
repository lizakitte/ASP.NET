using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace lab3_App.Models.CarModels
{
    public class Manufacturer
    {
        [Key]
        [HiddenInput]
        public int ManufacturerId { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Nazwa producenta")]
        public string Name { get; set; }
        public Address? Address { get; set; }
    }
}
