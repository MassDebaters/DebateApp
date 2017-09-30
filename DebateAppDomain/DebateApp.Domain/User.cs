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
            if (p.Validate()&& current.PostIsAllowed(p))
            {
                current.Responses.Add(p);
            }
        }
    }
}
