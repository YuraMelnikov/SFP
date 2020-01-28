using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class FastLap
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdGpResult { get; set; }
        [Required]
        public int Lap { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public float AverageSpeed { get; set; }

        [ForeignKey("IdGpResult")]
        public  GPResult Result { get; set; }
    }
}
