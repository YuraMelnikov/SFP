using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Participant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdGp { get; set; }
        [Required]
        public string Num { get; set; }
        [Required]
        public int IdTeam { get; set; }
        [Required]
        public int IdChassi { get; set; }
        [Required]
        public int IdEngine { get; set; }
        [Required]
        public int IdRacer { get; set; }
        [Required]
        public int IdTyre { get; set; }

        [ForeignKey("IdGp")]
        public  GP Gp { get; set; }
        [ForeignKey("IdTeam")]
        public  Team Team { get; set; }
        [ForeignKey("IdChassi")]
        public  Chassi Chassi { get; set; }
        [ForeignKey("IdEngine")]
        public  Engine Engine { get; set; }
        [ForeignKey("IdRacer")]
        public  Racer Racer { get; set; }
        [ForeignKey("IdTyre")]
        public  Tyre Tyre { get; set; }
    }
}
