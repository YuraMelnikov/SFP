using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class DNQ
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdGpResult { get; set; }
        [Required]
        public int IdTypeDnq { get; set; }

        [ForeignKey("IdGpResult")]
        public GPResult Result { get; set; }
        [ForeignKey("IdTypeDnq")]
        public  TypeDNQ TypeDnq { get; set; }
    }
}
