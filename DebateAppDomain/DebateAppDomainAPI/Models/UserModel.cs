using DebateApp.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebateAppDomainAPI.Models
{
    public class UserModel
    {
        private DBHelper dbh = new DBHelper();
        //for binding
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public int Astros { get; set; }
        //for logical operations
        public User UserLogic;

        public UserModel(User u)
        {
            UserLogic = u;
        }



    }
}
