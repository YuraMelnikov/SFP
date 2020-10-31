using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("ManufacturerImg")]
    public class ManufacturerImg : EntityImg 
    {
        [Required(ErrorMessage = "Manufacturer is required")]
        public Guid IdManufacturer { get; set; }

        [ForeignKey("IdManufacturer")]
        public Manufacturer Manufacturer { get; set; }
    }
}
