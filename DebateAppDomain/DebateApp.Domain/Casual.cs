using System;
using System.Collections.Generic;
using System.Text;

namespace DebateApp.Domain
{
    public class Casual : Debate
    {
        public Casual(User CreatedBy) : base()
        {
            DebatePost OpenerL = new DebatePost("No! The purpose of life is to eat, drink, and be merry!", CreatedBy);
            
            var c = new List<User>() { CreatedBy };
            DebateTopic = "Is life meaningless?";
            DebateCategory = "Dude, relax";
            Players = new Roster()
            {
                TeamLMembers = new Dictionary<bool, List<User>>(),
                TeamRMembers = new Dictionary<bool, List<User>>(),
                TeamLOpener = OpenerL
            };
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
