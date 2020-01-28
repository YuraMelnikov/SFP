using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Participant")]
    public class Participant : EntityId
    {
        [Required(ErrorMessage = "GP is required")]
        public Guid IdGp { get; set; }
        [Required(ErrorMessage = "Num is required")]
        public string Num { get; set; }
        [Required(ErrorMessage = "Team is required")]
        public Guid IdTeam { get; set; }
        [Required(ErrorMessage = "Chassi is required")]
        public Guid IdChassi { get; set; }
        [Required(ErrorMessage = "Engine is required")]
        public Guid IdEngine { get; set; }
        [Required(ErrorMessage = "Racer is required")]
        public Guid IdRacer { get; set; }
        [Required(ErrorMessage = "Tyre is required")]
        public Guid IdTyre { get; set; }

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
