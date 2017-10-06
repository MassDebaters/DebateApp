using System;
using System.Collections.Generic;
using System.Text;

namespace DebateApp.Domain
{
    public class Casual : Debate
    {
        public Casual(User CreatedBy, string Topic, string Category, string OpeningPost) : base()
        {
            DebateTopic = Topic;
            DebateCategory = Category;
            NumberOfPlayersPerTeam = 1;
            Teams.Add(new Team(NumberOfPlayersPerTeam));
            Teams.Add(new Team(NumberOfPlayersPerTeam));
            Teams[0].Members = new List<User>() { CreatedBy };
            Teams[0].Opener = new DebatePost(OpeningPost, CreatedBy.UserID);
            Audience = new List<User>();
            TurnLength = 60;
            PostLength = 200;
            SourcesRequired = 0;
            Round = new List<RoundState>();
            NumberOfRounds = 5;
            
        }
        public Casual() { }
    }
}
