using System;
using System.Collections.Generic;

namespace Convention.Domain.Models
{
    public class Speaker
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string ProfileUrl { get; set; }
        public bool Approved { get; set; }
        public IReadOnlyCollection<Talk> Talks { get; set; }
    }
}