using System;
using System.Collections.Generic;
using DebateApp.db;

namespace DebateApp.Domain
{
    public class User
    {
        public Accounts Account {get;set;}

        public int UserID { get; set; }
        public string UserPwd { get; set; }
        public string UserName { get; set; }
        public int UserAstros { get; set; }
        public List<Debate> YourDebates { get; set; }
        public List<Notification> Notifications { get; set; }


        public User(string name, string password)
        {
            Account = new UserHelper().Account(name, password);
        }

        public static User CreateUser(string name, string password)
        {
            User user = null;
            UserHelper helper = new UserHelper();
            bool uniqueUsername = helper.UniqueUsername(name);

            if(uniqueUsername){
                helper.AddAccount(name,password);
                user = new User(name, password);
            }
            return user;
        }
    }
}
