using System;

namespace Entities.DataTransferObjects
{
    public class LeaderLapUpdateDto
    {
        public Guid IdGpResult { get; set; }
        public int First { get; set; }
        public int Last { get; set; }
    }
}
