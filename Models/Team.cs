using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdCountry { get; set; }
        [Required]
        public string ShortName { get; set; }
        [Required]
        public int IndexPhoto { get; set; }

        [ForeignKey("IdCountry")]
        public Country Cournt { get; set; }
        [ForeignKey("IndexPhoto")]
        public ImageGP Image { get; set; }
    }
}
