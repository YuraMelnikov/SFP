using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("TypeFinish")]
    public class TypeFinish : EntityId
    {
        [Required(ErrorMessage = "Shortname is required")]
        public string ShortName { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
