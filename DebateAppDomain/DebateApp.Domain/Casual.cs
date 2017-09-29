using System;
using System.Collections.Generic;
using System.Text;

namespace DebateApp.Domain
{
    public class Casual : Debate
    {
        public Casual(User CreatedBy) : base()
        {
            var c = new List<User>() { CreatedBy };
            DebateTopic = "Is life meaningless?";
            DebateCategory = "Dude, relax";
            Players = new Roster()
            {
                TeamLMembers = new Dictionary<bool, List<User>>().Add(false,c),


        };

        }
    }
}
