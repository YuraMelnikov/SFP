using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("TypeDNQ")]
    public class TypeDNQ : EntityId
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
