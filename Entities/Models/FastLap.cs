using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("FastLap")]
    public class FastLap : EntityId
    {
        [Required(ErrorMessage = "Result Grand prix is required")]
        public Guid IdGrandPrixResult { get; set; }
        [Required(ErrorMessage = "Lap is required")]
        public int Lap { get; set; }
        [Required(ErrorMessage = "Time is required")]
        public TimeSpan Time { get; set; }
        [Required(ErrorMessage = "Average speed is required")]
        public float AverageSpeed { get; set; }

        [ForeignKey("IdGrandPrixResult")]
        public GrandPrixResult GrandPrixResult { get; set; }
    }
}
