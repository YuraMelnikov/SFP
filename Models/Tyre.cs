using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Tyre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdManufacturer { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int IdImageGp { get; set; }

        [ForeignKey("IdImageGp")]
        public ImageGP ImageGp { get; set; }
        [ForeignKey("IdManufacturer")]
        public  Manufacturer Manufacturer { get; set; }
    }
}
