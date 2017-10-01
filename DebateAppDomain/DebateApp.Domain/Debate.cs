using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DebateApp.Domain
{
    public abstract class Debate
    {

        private bool _gamestage = false;
        public bool GameStage { get { return _gamestage; } }
        public string DebateTopic { get; set; }
        public string DebateCategory { get; set; }
        public static int NumberOfPlayersPerTeam { get; set; }
        public List<Team> Teams = new List<Team>() { new Team(NumberOfPlayersPerTeam),
                                                     new Team(NumberOfPlayersPerTeam) };
        public List<User> Audience { get; set; }
        public int TurnLength { get; set; }
        public int PostLength { get; set; }
        public int SourcesRequired { get; set; }
        public List<RoundState> Round = new List<RoundState>();
        public RoundState ActiveRound() { return Round[Round.Count-1]; }
        public int NumberOfRounds { get; set; }
        
        public int Pot { get; set; }
        public bool SetupStage
        {
            get
            {
                if (Teams.TrueForAll(t => t.ReadyToStart))
                {
                    _gamestage = true;
                    return false;
                }
                else { return true; }
            }
        }

        public void UpdatePosts(DebatePost p)
        {

        
            
        }
    }
}
