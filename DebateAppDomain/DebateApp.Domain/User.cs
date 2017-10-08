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


        public Debate Post(string p, Debate d)
        {
            d.GetStage();
            var res = new DebatePost(p, UserID); 
            
            if (res.Validate() && HasResponded==false && d._gamestage)
            {
                d.ActiveRound().Responses.Add(res);
                HasResponded = true;
                return d;
            }
            else
            {
                d.Status = "You cannot post at this time. Either your post is too long, or you have already responded in this round.";
                return d;
            }
        }
        public Debate Vote(Debate d, bool team)
        {
           
            if (HasVoted == false && d.Audience.Contains(this))
            {
                d.ActiveRound().Vote(team);
                HasVoted = true;
            }
            return d;
        }

        public Debate JoinDebate(Debate d, DebatePost p, bool TeamR)
        {
            d.GetStage();
            var i = 0;
            if(TeamR) { i += 1; }
            var check = d.Teams[i].IsNotFull() && d.SetupStage;
            if (check)
            {
                d.Teams[i].Members.Add(this);
                d.Teams[i].Opener = p;
                d.GetStage();
                return d;
            }
            else
            {
                return d;
                throw new Exception("Team is full!");
            }
        }
        public Debate ViewDebate(Debate d)
        {
            if (!d.Audience.Contains(this))
            {
                d.Audience.Add(this);
                return d;
            }
            else return d;
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
