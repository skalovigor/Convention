using System;

namespace Convention.Contracts.Models.Talk
{
    public record TalkCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int AmountOfSeats { get; set; }
    }
}