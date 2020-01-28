using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Season
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int IdImageGp { get; set; }
        [Required]
        public int IdTypeCalculate { get; set; }

        [ForeignKey("IdImageGp")]
        public ImageGP Image { get; set; }
        [ForeignKey("IdTypeCalculate")]
        public TypeCalculate TypeCalculat { get; set; }
    }
}
