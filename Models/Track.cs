using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Track
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdCountry { get; set; }
        [Required]
        public int IdImageGp { get; set; }
        [Required]
        public string NameEn { get; set; }
        [Required]
        public string NameRus { get; set; }

        [ForeignKey("IdCountry")]
        public  Country Countr { get; set; }
        [ForeignKey("IdImageGp")]
        public ImageGP Image { get; set; }
    }
}
