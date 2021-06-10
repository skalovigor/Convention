using System;

namespace Convention.Contracts.Models.Talk
{
    public record TalkResponse
    {
        public Guid Id { get; set; }
        public Guid SpeakerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int AmountOfSeats { get; set; }
    }
}