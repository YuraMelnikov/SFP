using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Qualification")]
    public class Qualification : EntityId
    {
        [Required(ErrorMessage = "Participant is required")]
        public Guid IdParticipant { get; set; }
        [Required(ErrorMessage = "Position is required")]
        public int Position { get; set; }
        [Required(ErrorMessage = "Time is required")]
        public TimeSpan Time { get; set; }
        [Required(ErrorMessage = "Average speed is reqiured")]
        public float AverageSpeed { get; set; }

        [ForeignKey("IdParticipant")]
        public  Participant Participant { get; set; }
    }
}
