using System;

namespace Entities.DataTransferObjects
{
    public class FastLapUpdateDto
    {
        public Guid IdGpResult { get; set; }
        public int Lap { get; set; }
        public TimeSpan Time { get; set; }
        public float AverageSpeed { get; set; }
    }
}
