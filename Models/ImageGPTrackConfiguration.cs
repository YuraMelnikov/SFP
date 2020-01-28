using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ImageGPTrackConfiguration
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Link { get; set; }
    }
}
