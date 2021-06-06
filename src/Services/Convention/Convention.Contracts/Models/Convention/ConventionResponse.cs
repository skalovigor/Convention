using System;

namespace Convention.Contracts.Models
{
    public record ConventionResponse
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartDateFormatted  => StartDate.ToString("D");
        public string EndDateFormatted  => EndDate.ToString("D");
        public string Information { get; set; }
        public string BannerUrl { get; set; }
        public string Address { get; set; }
    }
}