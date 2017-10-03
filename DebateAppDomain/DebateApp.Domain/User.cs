using System;
using System.Collections.Generic;


namespace DebateApp.Domain
{
    public class User
    {
       

        public int UserID { get; set; }
        public string Username { get; set; }
        //public string Password { get; set; }
        public int Astros { get; set; }
        //public List<int> YourDebates { get; set; }
        //public List<int> Notifications { get; set; }
        public bool HasVoted = false;
        public bool HasResponded = false;

        public User(int id, string username, int astros)
        {
            UserID = id;
            Username = username;
            Astros = astros;
        }


        public void Post(DebatePost p, Debate d)
        {
            
            if (p.Validate() && HasResponded==false)
            {
                d.ActiveRound().Responses.Add(p);
                HasResponded = true;
            }
        }
        public void Vote(Debate d, bool team)
        {
           
            if (HasVoted == false && d.Audience.Contains(this))
            {
                d.ActiveRound().Vote(team);
                HasVoted = true;
            }
        }

        public void JoinDebate(Debate d, DebatePost p, bool TeamR)
        {
            var i = 0;
            if(TeamR) { i += 1; }
            if (d.Teams[i].IsNotFull()&&d.SetupStage)
            {
                d.Teams[1].Members.Add(this);
            }
        }
        public void ViewDebate(Debate d)
        {
            if(!d.Audience.Contains(this))
            {
                d.Audience.Add(this);
            }
        }

        public void LeaveDebate(Debate d)
        {
            if(d.Audience.Contains(this))
            {
                d.Audience.Remove(this);
            }
        }
    }
}
