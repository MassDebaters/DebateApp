using System;
using System.Collections.Generic;
using System.Text;

namespace DebateApp.Domain
{
    public class RoundState
    {
        
        public List<DebatePost> Responses { get; set; }
        public int VotesL { get; set; }
        public int VotesR {get; set;}
        public double SwingL { get; set; }
        public double SwingR { get; set; }
        public int CurrentTurn { get; set; }
        public int TeamCount { get; set; }
        public List<User> TeamLMembers { get; set; }
        public List<User> TeamRMembers { get; set; }



        public void UpdateDebate(DebatePost d)
        {
            if (d.Validate() && (Responses.Find(r => r.Team == d.Team) == null))
            {
                Responses.Add(d);
            }
        }

        public bool PostIsAllowed(DebatePost p)
        {
            var 
        }
    }
}
