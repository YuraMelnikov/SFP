using System;

namespace Entities.DataTransferObjects
{
    public class TeamUpdateDto
    {
        public Guid IdCountry { get; set; }
        public string ShortName { get; set; }
        public Guid IdImage { get; set; }
    }
}
