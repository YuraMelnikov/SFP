using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Fail")]
    public class Fail : EntityId
    {
        [Required(ErrorMessage = "Result GP is required")]
        public Guid IdGpResult { get; set; }
        [Required(ErrorMessage = "Type fail is required")]
        public Guid IdTypeFail { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [ForeignKey("IdGpResult")]
        public  GPResult GPResult { get; set; }
        [ForeignKey("IdTypeFail")]
        public  TypeFail TypeFail { get; set; }
    }
}
