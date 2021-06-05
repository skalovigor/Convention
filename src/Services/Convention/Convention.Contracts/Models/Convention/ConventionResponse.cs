﻿using System;

namespace Convention.Contracts.Models
{
    public record ConventionResponse
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Information { get; set; }
    }
}