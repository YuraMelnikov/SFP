﻿using System;

namespace Entities.DataTransferObjects
{
    public class TeamNameUpdateDto
    {
        public Guid IdSeasonStart { get; set; }
        public Guid IdSeasonFinish { get; set; }
        public string LongName { get; set; }
    }
}
