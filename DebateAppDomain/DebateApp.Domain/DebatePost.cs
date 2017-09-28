﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DebateApp.Domain
{
    public class DebatePost : Post
    {
        public string Team { get; set; }
        public int Astros { get; set; }
        public Dictionary<String,String> Sources { get; set; }

    }
}