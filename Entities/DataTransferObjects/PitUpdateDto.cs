using System;

namespace Entities.DataTransferObjects
{
    public class PitUpdateDto
    {
        public Guid IdGpResult { get; set; }
        public int Lap { get; set; }
        public TimeSpan Time { get; set; }
    }
}
