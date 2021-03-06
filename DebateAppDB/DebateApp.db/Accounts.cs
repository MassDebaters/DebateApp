﻿using System;
using System.Collections.Generic;

namespace DebateApp.db
{
    public partial class Accounts
    {
        public Accounts()
        {
            Posts = new HashSet<Posts>();
        }

        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Astros { get; set; }
        public string Role { get; set; }

        public ICollection<Posts> Posts { get; set; }
    }
}
