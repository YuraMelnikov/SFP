﻿using System;

namespace Entities.DataTransferObjects
{
    public class GPResultDto
    {
        public Guid Id { get; set; }
        public TimeSpan Time { get; set; }
        public float AverageSpeed { get; set; }
        public int Lap { get; set; }
        public ParticipantDto ParticipantDto { get; set; }
        public TypeFinishDto TypeFinishDto { get; set; }
    }
}
