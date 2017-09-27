using System;
using System.Collections.Generic;
using System.Text;

namespace DebateApp.Domain
{
    public class RoundState
    {
        public int Timer { get; set; }
        public List<DebatePost> Responses { get; set; }
        public Dictionary<int,string> Votes { get; set; }
        public double SwingA { get; set; }
        public double SwingB { get; set; }

    }
}
