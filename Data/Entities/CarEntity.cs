using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data.Entities
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

    [Table("car")]
    public class CarEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }
        public int ManufacturerId { get; set; }
        public ManufacturerEntity? Manufacturer { get; set; }
        public decimal? Capacity { get; set; }
        public decimal? Power { get; set; }
        public Engine EngineType { get; set; }
        [Required]
        public int RegistratioinNumber { get; set; }
        public int? ContactId { get; set; }
        public ContactEntity? OwnerContact { get; set; }

    }
}
