using System;
using System.Collections.Generic;


namespace DebateApp.Domain
{
    public class User
    {
        //private Accounts _account {get;set;}

        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Astros { get; set; }
        public List<int> YourDebates { get; set; }
        public List<int> Notifications { get; set; }


        //public User(string name, string password)
        //{
        //    _account = UserHelper.Account(name, password);
        //}

        public Debate Post(DebatePost p, Debate d)
        {
            d.UpdatePosts(p);
            return d;
        }
    }
}
