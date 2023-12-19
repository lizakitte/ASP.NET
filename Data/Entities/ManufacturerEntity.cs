using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ManufacturerEntity
    {
        [Key]
        public int ManufacturerId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public Address Address { get; set; }
        public ISet<CarEntity> Cars { get; set; }
    }
}
