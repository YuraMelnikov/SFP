using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ImageGPFlag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Link { get; set; }
    }
}
