using System;
using System.Collections.Generic;


namespace DebateApp.Domain
{
    public class User
    {
       

        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Astros { get; set; }
        public List<int> YourDebates { get; set; }
        public List<int> Notifications { get; set; }
        public bool HasVoted = false;
        public bool HasResponded = false;
        



        public void Post(DebatePost p, Debate d)
        {
            var current = d.Round[d.Round.Count];
            if (p.Validate() && HasResponded==false)
            {
                current.Responses.Add(p);
                HasResponded = true;
            }
        }
        public void Vote(Debate d, bool team)
        {
            var current = d.Round[d.Round.Count];
            if (HasVoted == false)
            {
                current.Vote(team);
                HasVoted = true;
            }
        }

        public void JoinDebate(Debate d, DebatePost p)
        {
            if(!d.Teams.TeamRMembers.Contains(this))
            {
                d.Teams.TeamRMembers.Add(this);
            }
            
            if (p.Validate())
            {
                d.Teams.TeamROpener = p;
            }
            
        }
    }
}
