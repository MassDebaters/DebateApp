using System;
using System.Collections.Generic;
using System.Text;

namespace DebateApp.Domain
{
    public class Casual : Debate
    {
        public Casual(User CreatedBy, string Topic, string Category, string OpeningPost) : base()
        {
            
            
            var c = new List<User>() { CreatedBy };
            DebateTopic = Topic;
            DebateCategory = Category;
            Teams = new List<Team>()
            {
                new Team()
                {
                    Opener = new DebatePost(OpeningPost, CreatedBy),
                    TeamLimit = 1,
                    Members = new List<User>() { CreatedBy }
                },
                new Team()
                {
                    TeamLimit = 1,
                    Members = new List<User>()
                }
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
