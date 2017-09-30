﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DebateApp.Domain
{
    public class Casual : Debate
    {
        public Casual(User CreatedBy, string Topic, string Category, string Opener) : base()
        {
            
            
            var c = new List<User>() { CreatedBy };
            DebateTopic = Topic;
            DebateCategory = Category;
            Players = new Roster()
            {
                TeamLMembers = new Dictionary<bool, List<User>>(),
                TeamRMembers = new Dictionary<bool, List<User>>(),
                TeamLOpener = new DebatePost(Opener, CreatedBy)
            };
            Players.TeamLMembers.Add(false, c);
            Audience = new List<User>();
            TurnLength = 60;
            PostLength = 200;
            SourcesRequired = 0;
            Round = new List<RoundState>();
            NumberOfRounds = 5;
            NumberOfPlayersPerTeam = 1;

        }
    }
}
