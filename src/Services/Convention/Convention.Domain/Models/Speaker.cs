﻿using System;
using System.Collections.Generic;

namespace Convention.Domain
{
    public class Speaker
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public List<Talk> Talks { get; set; }
    }
}