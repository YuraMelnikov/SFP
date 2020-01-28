using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TypeDNQ
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
