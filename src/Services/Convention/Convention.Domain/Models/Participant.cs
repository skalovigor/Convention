using System;
using System.Collections.Generic;

namespace Convention.Domain.Models
{
    public class Participant
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Guid ConventionId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Convention Convention { get; set; }
        public IReadOnlyCollection<TalkParticipant> TalkParticipants { get; set; }
    }
}