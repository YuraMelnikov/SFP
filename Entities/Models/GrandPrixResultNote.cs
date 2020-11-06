using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("GrandPrixResultNote")]
    public class GrandPrixResultNote : EntityId
    {
        [Required(ErrorMessage = "Result Grand prix is required")]
        public Guid IdGrandPrixResult { get; set; }
        [Required(ErrorMessage = "Note is required")]
        public string Note { get; set; }

        [ForeignKey("IdGrandPrixResult")]
        public GrandPrixResult GrandPrixResult { get; set; }
    }
}
