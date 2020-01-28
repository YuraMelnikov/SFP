using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ImageGPRacers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Link { get; set; }
    }
}
