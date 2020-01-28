using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Team")]
    public class Team : EntityId
    {
        [Required(ErrorMessage = "Country is required")]
        public Guid IdCountry { get; set; }
        [Required(ErrorMessage = "Shortname is required")]
        public string ShortName { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public Guid IdImage { get; set; }

        [ForeignKey("IdCountry")]
        public Country Country { get; set; }
        [ForeignKey("IdImage")]
        public Image Image { get; set; }
    }
}
