using System;

namespace Entities.DataTransferObjects
{
    public class DNQCreateDto
    {
        public Guid IdGpResult { get; set; }
        public Guid IdTypeDnq { get; set; }
        public string Description { get; set; }
    }
}
