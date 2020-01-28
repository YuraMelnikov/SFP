using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Season")]
    public class Season : EntityId
    {
        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public Guid IdImage { get; set; }
        [Required(ErrorMessage = "Type calculate is required")]
        public Guid IdTypeCalculate { get; set; }

        [ForeignKey("IdImage")]
        public Image Image { get; set; }
        [ForeignKey("IdTypeCalculate")]
        public TypeCalculate TypeCalculate { get; set; }
    }
}
