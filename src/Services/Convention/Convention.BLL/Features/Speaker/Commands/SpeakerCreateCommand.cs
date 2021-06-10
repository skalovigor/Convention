using MediatR;

namespace Convention.BLL.Features.Speaker.Commands
{
    //TODO: validation
    public record SpeakerCreateCommand : IRequest
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string ProfileUrl { get; set; }
    }
}