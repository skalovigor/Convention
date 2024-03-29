﻿using System;

namespace Convention.Domain.Models
{
    public class TalkParticipant
    {
        public Guid Id { get; set; }
        public Guid ParticipantId { get; set; }
        public Guid TalkId { get; set; }
        public Talk Talk { get; set; }
        public Participant Participant { get; set; }
    }
}