﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebateAppDomainAPI.Models
{
    public class CreateCasualModel
    {
        public int UserID { get; set; }
        public string Topic { get; set; }
        public string Category { get; set; }
        public string Opener { get; set; }
    }
}
