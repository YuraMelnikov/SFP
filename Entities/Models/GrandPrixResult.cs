using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("GrandPrixResult")]
    public class GrandPrixResult : EntityId
    {
        [Required(ErrorMessage = "Participant is required")]
        public Guid IdParticipant { get; set; }
        [Required(ErrorMessage = "Time is required")]
        public TimeSpan Time { get; set; }
        [Required(ErrorMessage = "Average speed is required")]
        public float AverageSpeed { get; set; }
        [Required(ErrorMessage = "Lap is required")]
        public int Lap { get; set; }
        [Required(ErrorMessage = "Points is required")]
        public float Points { get; set; }
        [Required(ErrorMessage = "Position is required")]
        public int? Position { get; set; }

        [ForeignKey("IdParticipant")]
        public  Participant Participant { get; set; }
    }
}
