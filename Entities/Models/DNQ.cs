using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("DNQ")]
    public class DNQ : EntityId
    {
        [Required(ErrorMessage = "Result GP is required")]
        public Guid IdGpResult { get; set; }
        [Required(ErrorMessage = "Type DNQ is required")]
        public Guid IdTypeDnq { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [ForeignKey("IdGpResult")]
        public GPResult GPResult { get; set; }
        [ForeignKey("IdTypeDnq")]
        public  TypeDNQ TypeDnq { get; set; }
    }
}
