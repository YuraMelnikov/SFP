using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class StartPositionType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Map { get; set; }
        [Required]
        public int IdImageGp { get; set; }

        [ForeignKey("IdImageGp")]
        public  ImageGP Image { get; set; }
    }
}
