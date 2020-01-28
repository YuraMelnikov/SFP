using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("TeamName")]
    public class TeamName : EntityId
    {
        [Required(ErrorMessage = "Season start is required")]
        public Guid IdSeasonStart { get; set; }
        [Required(ErrorMessage = "Season finish is required")]
        public Guid IdSeasonFinish { get; set; }
        [Required(ErrorMessage = "Long name is required")]
        public string LongName { get; set; }

        [ForeignKey("IdSeasonStart")]
        public Season SeasonStart { get; set; }
        [ForeignKey("IdSeasonFinish")]
        public Season SeasonFinish { get; set; }
    }
}
