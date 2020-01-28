using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdCountry { get; set; }
        [Required]
        public int IdImageGp { get; set; }
        [Required]
        public string Name { get; set; }

        [ForeignKey("IdCountry")]
        public Country Countr { get; set; }
        [ForeignKey("IdImageGp")]
        public ImageGP Image { get; set; }
    }
}
