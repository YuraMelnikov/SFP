using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Fail")]
    public class Fail : EntityId
    {
        [Required(ErrorMessage = "Result Grand prix is required")]
        public Guid IdGrandPrixResult { get; set; }
        [Required(ErrorMessage = "Type fail is required")]
        public Guid IdTypeFail { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Note { get; set; }

        [ForeignKey("IdGrandPrixResult")]
        public  GrandPrixResult GrandPrixResult { get; set; }
        [ForeignKey("IdTypeFail")]
        public  TypeFail TypeFail { get; set; }
    }
}
