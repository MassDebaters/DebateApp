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
            
            if (p.Validate() && HasResponded==false)
            {
                d.ActiveRound.Responses.Add(p);
                HasResponded = true;
            }
        }
        public void Vote(Debate d, bool team)
        {
           
            if (HasVoted == false)
            {
                d.ActiveRound.Vote(team);
                HasVoted = true;
            }
        }

        public void JoinDebate(Debate d, DebatePost p, bool TeamR)
        {
            
            
        }
    }
}
