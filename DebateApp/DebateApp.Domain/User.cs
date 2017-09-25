using System;
using System.Collections.Generic;

namespace DebateApp.Domain
{
    public class User
    {
        public int UserID { get; set; }
        public string UserPwd { get; set; }
        public string UserName { get; set; }
        public int UserAstros { get; set; }
        public List<Debate> YourDebates { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}
