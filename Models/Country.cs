using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NameEn { get; set; }
        [Required]
        public string NameRus { get; set; }
        [Required]
        public int IdImageGpFlag { get; set; }
        [ForeignKey("IdImageGpFlag")]
        public  ImageGPFlag Image { get; set; }
    }
}
