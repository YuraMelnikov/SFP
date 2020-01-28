using System;

namespace Entities.DataTransferObjects
{
    public class DNQDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public GPResultDto GPResultDto { get; set; }
        public TypeDNQDto TypeDNQDto { get; set; }
    }
}
