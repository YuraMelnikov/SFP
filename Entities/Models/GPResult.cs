using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("GPResult")]
    public class GPResult : EntityId
    {
        [Required(ErrorMessage = "Participant is required")]
        public Guid IdParticipant { get; set; }
        [Required(ErrorMessage = "Time is required")]
        public TimeSpan Time { get; set; }
        [Required(ErrorMessage = "Average speed is required")]
        public float AverageSpeed { get; set; }
        [Required(ErrorMessage = "Type finish is required")]
        public Guid IdTypeFinish { get; set; }
        [Required(ErrorMessage = "Lap is required")]
        public int Lap { get; set; }

        [ForeignKey("IdParticipant")]
        public  Participant Participant { get; set; }
        [ForeignKey("IdTypeFinish")]
        public TypeFinish TypeFinish { get; set; }
    }
}
