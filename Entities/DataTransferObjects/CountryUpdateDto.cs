﻿using System;

namespace Entities.DataTransferObjects
{
    public class CountryUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid IdImage { get; set; }
    }
}
