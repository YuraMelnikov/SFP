using System;

namespace Entities.DataTransferObjects
{
    public class FailCreateDto
    {
        public Guid IdGpResult { get; set; }
        public Guid IdTypeFail { get; set; }
        public string Description { get; set; }
    }
}
