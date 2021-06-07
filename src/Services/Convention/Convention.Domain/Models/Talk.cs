using System;
using System.Collections.Generic;
using Convention.Domain.Enums;

namespace Convention.Domain.Models
{
    public class Talk
    {
        public Guid Id { get; set; }
        public Guid ConventionId { get; set; }
        public Guid SpeakerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TalkStatus Status { get; set; }
        public int AmountOfSeats { get; set; }
        
        public Convention Convention { get; set; }
        public IReadOnlyCollection<TalkParticipant> TalkParticipants { get; set; }
        public Speaker Speaker { get; set; }
    }
}