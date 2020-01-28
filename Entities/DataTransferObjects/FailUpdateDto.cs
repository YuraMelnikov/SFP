using System;

namespace Entities.DataTransferObjects
{
    public class FailUpdateDto
    {
        public Guid IdGpResult { get; set; }
        public Guid IdTypeFail { get; set; }
        public string Description { get; set; }
    }
}
