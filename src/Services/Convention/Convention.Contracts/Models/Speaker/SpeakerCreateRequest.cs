namespace Convention.Contracts.Models.Speaker
{
    public record SpeakerCreateRequest
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string ProfileUrl { get; set; }
    }
}