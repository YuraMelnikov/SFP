using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Fine")]
    public class Fine : EntityId
    {
        [Required(ErrorMessage = "Gp result is required")]
        public Guid IdGpResult { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [ForeignKey("IdGpResult")]
        public GPResult Result { get; set; }
    }
}
