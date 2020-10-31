using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("TeamImg")]
    public class TeamImg : EntityImg
    {
        [Required(ErrorMessage = "Team is required")]
        public Guid IdTeam { get; set; }

        [ForeignKey("IdTeam")]
        public Team Team { get; set; }
    }
}
