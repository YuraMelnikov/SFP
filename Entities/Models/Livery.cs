using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Livery")]
    public class Livery : EntityId
    {
        [Required(ErrorMessage = "Link is required")]
        public string Link { get; set; }
    }
}
