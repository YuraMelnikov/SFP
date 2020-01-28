using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("FastLap")]
    public class FastLap : EntityId
    {
        [Required(ErrorMessage = "Result GP is required")]
        public Guid IdGpResult { get; set; }
        [Required(ErrorMessage = "Lap is required")]
        public int Lap { get; set; }
        [Required(ErrorMessage = "Time is required")]
        public TimeSpan Time { get; set; }
        [Required(ErrorMessage = "Average speed is required")]
        public float AverageSpeed { get; set; }

        [ForeignKey("IdGpResult")]
        public GPResult GPResult { get; set; }
    }
}
