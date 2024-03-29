﻿namespace Convention.Contracts.Models.Participant
{
    public record ParticipantCreateRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}