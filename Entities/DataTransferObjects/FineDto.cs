using System;

namespace Entities.DataTransferObjects
{
    public class FineDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public GPResultDto GPResultDto { get; set; }
    }
}
