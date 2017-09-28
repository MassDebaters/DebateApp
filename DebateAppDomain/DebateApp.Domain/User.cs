using System;
using System.Collections.Generic;


namespace DebateApp.Domain
{
    public class User
    {
        private Accounts _account {get;set;}

        public int UserID { get {return _account.AccountId;}}
        public string Username { get {return _account.Username;}}
        public string Password { get {return _account.Password;}}
        public int Astros { get {return _account.Astros;}}
        public List<Debate> YourDebates { get; set; }
        public List<Notification> Notifications { get; set; }


        public User(string name, string password)
        {
            _account = UserHelper.Account(name, password);
        }

        public Debate Post(Post p, Debate d)
        {
            var UpdatedDebate = d;
            d.UpdatePosts(p);
            return d;
        }
    }
}
