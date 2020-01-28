using System;
using System.Collections.Generic;

namespace Entities.DataTransferObjects
{
    public  class CountryDto
    {
        public Guid Id;
        public string Name { get; set; }
        public IEnumerable<ImageDto> Images { get; set; }
    }
}
