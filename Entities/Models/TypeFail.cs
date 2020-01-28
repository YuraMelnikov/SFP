using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("TypeFail")]
    public class TypeFail : EntityId
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
