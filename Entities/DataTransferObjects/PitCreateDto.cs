using System;

namespace Entities.DataTransferObjects
{
    public class PitCreateDto
    {
        public Guid IdGpResult { get; set; }
        public int Lap { get; set; }
        public TimeSpan Time { get; set; }
    }
}
