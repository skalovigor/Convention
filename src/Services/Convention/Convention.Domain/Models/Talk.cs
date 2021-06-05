using System;
using System.Collections.Generic;
using Convention.Domain.Enums;

namespace Convention.Domain
{
    public class Talk
    {
        public Guid Id { get; set; }
        public Guid ConventionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TalkStatus Status { get; set; }
        public int AmountOfSeats { get; set; }
        
        public Convention Convention { get; set; }
        public List<TalkParticipant> TalkParticipants { get; set; }
    }
}