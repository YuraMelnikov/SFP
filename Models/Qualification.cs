using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Qualification
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdParticipant { get; set; }
        [Required]
        public int Position { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public float AverageSpeed { get; set; }

        [ForeignKey("IdParticipant")]
        public  Participant Participant { get; set; }
    }
}
