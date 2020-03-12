using System;

namespace Entities.DataTransferObjects
{
    public class TypeFinishUpdateDto
    {
        public Guid Id { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
    }
}
