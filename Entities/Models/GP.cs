using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Entities.Models
{
    [Table("GP")]
    public class GP : EntityId
    {
        [Required(ErrorMessage = "Track configuration is required")]
        public Guid IdTrackСonfiguration { get; set; }
        [Required(ErrorMessage = "Num is required")]
        public int Num { get; set; }
        [Required(ErrorMessage = "Num in season is required")]
        public int NumInSeason { get; set; }
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
