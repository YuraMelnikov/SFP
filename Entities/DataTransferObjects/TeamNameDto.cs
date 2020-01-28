﻿using System;

namespace Entities.DataTransferObjects
{
    public class TeamNameDto
    {
        public Guid Id { get; set; }
        public string LongName { get; set; }
        public SeasonDto SeasonStart { get; set; }
        public SeasonDto SeasonFinish { get; set; }
    }
}
