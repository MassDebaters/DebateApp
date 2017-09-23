using System;
using System.Collections.Generic;
using System.Text;

namespace DebateApp.Domain
{
    public abstract class Debate
    {
        public int DebateID { get; set; }
        public List<Post> Posts { get; set; }
        public string DebateTopic { get; set; }
        public string DebateCategory { get; set; }
        public Dictionary<string,List<User>> Teams { get; set; }
        public List<User> Audience { get; set; }
        public int CurrentTurn { get; set; }
        public int TurnLength { get; set; }
        public int PostLength { get; set; }
        public int SourcesRequired { get; set; }
        public List<RoundState> Round { get; set; }
        public int NumberOfRounds { get; set; }
        public int Pot { get; set; }
    }
}
