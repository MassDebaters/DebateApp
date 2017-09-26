using System;
using DebateApp.Domain;
using System.Collections.Generic;

namespace DebateApp.Client.Models
{
    public class SessionBagModel
    {
        public User User { get; set; }
        public List<Debate> Debates {get; set;}
    }
}