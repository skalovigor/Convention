using System;
using System.Collections.Generic;

namespace Convention.Domain
{
    public class Convention
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Information { get; set; }
        public string BannerUrl { get; set; }
        
        public List<Talk> Talks { get; set; }
        public List<Participant> Participants { get; set; }
    }
}