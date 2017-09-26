using System;

namespace DebateApp.Client.Models
{
    public class UserModel
    {
        public string Username { get; set;}
        public string Password { get; set;}

        // will just give User domain a static constructor and remove this class. 
        public static UserModel CreateUserModel(string username, string password)
        {
            UserModel user = new UserModel(); 
            user.Username = username;
            user.Password = password;
            return user;
        }
    }

}