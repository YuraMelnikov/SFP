﻿using System;

namespace Entities.DataTransferObjects
{
    public class TrackUpdateDto
    {
        public Guid IdCountry { get; set; }
        public Guid IdImage { get; set; }
        public string Name { get; set; }
    }
}
