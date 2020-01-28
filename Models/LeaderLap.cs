using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class LeaderLap
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdGpResult { get; set; }
        [Required]
        public int First { get; set; }
        [Required]
        public int Last { get; set; }

        [ForeignKey("IdGpResult")]
        public GPResult Result { get; set; }
    }
}
