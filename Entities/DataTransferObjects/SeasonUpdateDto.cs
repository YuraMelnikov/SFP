using System;

namespace Entities.DataTransferObjects
{
    public class SeasonUpdateDto
    {
        public int Year { get; set; }
        public Guid IdImage { get; set; }
        public Guid IdTypeCalculate { get; set; }
    }
}
