using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TypeCalculate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DescriptionEn { get; set; }
        [Required]
        public string DescriptionRus { get; set; }
    }
}
