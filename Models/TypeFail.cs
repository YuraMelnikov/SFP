using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TypeFail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
