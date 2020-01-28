using System;

namespace Entities.DataTransferObjects
{
    public class ChassiDto
    {
        public Guid Id;
        public string Name { get; set; }
        public ManufacturerDto ManufacturerDto { get; set; }
        public ImageDto ImageDto { get; set; }
        public LiveryDto LiveryDto { get; set; }
    }
}
