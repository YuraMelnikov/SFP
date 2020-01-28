using System;

namespace Entities.DataTransferObjects
{
    public class PitDto
    {
        public Guid Id { get; set; }
        public int Lap { get; set; }
        public TimeSpan Time { get; set; }
        public GPResultDto GPResultDto { get; set; }
    }
}
