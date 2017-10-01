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
        public int UserID { get; set; }
        public User user { get; set; }
        public string UserString => JsonConvert.SerializeObject(user);

    }
}
