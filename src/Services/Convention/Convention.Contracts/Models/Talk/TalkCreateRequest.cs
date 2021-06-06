using System;

namespace Convention.Contracts.Models.Talk
{
    public class TalkCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }
        public int AmountOfSeats { get; set; }
    }
}