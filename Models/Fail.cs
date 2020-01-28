using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Fail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdGpResult { get; set; }
        [Required]
        public int IdTypeFail { get; set; }

        [ForeignKey("IdGpResult")]
        public  GPResult Result { get; set; }
        [ForeignKey("IdTypeFail")]
        public  TypeFail TFail { get; set; }
    }
}
