using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("LeaderLap")]
    public class LeaderLap : EntityId
    {
        [Required(ErrorMessage = "Result GP is required")]
        public Guid IdGpResult { get; set; }
        [Required(ErrorMessage = "First is required")]
        public int First { get; set; }
        [Required(ErrorMessage = "Last is required")]
        public int Last { get; set; }

        [ForeignKey("IdGpResult")]
        public GPResult GPResult { get; set; }
    }
}
