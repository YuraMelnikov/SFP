using System;

namespace Entities.DataTransferObjects
{
    public class FailDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public GPResultDto GPResultDto { get; set; }
        public TypeFailDto TypeFailDto { get; set; }
    }
}
