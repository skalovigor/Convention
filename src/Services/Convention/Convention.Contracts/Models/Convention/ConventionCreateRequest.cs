using System;

namespace Convention.Contracts.Models.Convention
{
    public record ConventionCreateRequest
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Information { get; set; }
        public string BannerUrl { get; set; }
        public string Address { get; set; }
    }
}