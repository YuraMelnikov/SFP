using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Entities.Models
{
    [Table("GrandPrix")]
    public class GrandPrix : EntityId
    {
        [Required(ErrorMessage = "Track configuration is required")]
        public Guid IdTrackСonfiguration { get; set; }
        [Required(ErrorMessage = "Number is required")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Number in season is required")]
        public int NumberInSeason { get; set; }
        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public Guid IdImage { get; set; }
        [Required(ErrorMessage = "Weather is required")]
        public string Weather { get; set; }
        [Required(ErrorMessage = "Percent distance is required")]
        public float PercentDistance { get; set; }

        [ForeignKey("IdTrackСonfiguration")]
        public TrackСonfiguration TrackСonfiguration { get; set; }
        [ForeignKey("IdImage")]
        public  Image Image { get; set; }
    }
}
