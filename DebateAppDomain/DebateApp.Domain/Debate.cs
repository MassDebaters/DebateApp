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


        //public int DebateID { get; set; }
        private bool _gamestage = false;
        public bool GameStage { get { return _gamestage; } }
        //public List<Post> Comments { get; set; }
        public string DebateTopic { get; set; }
        public string DebateCategory { get; set; }
        public Roster Players { get; set; }
        public List<User> Audience { get; set; }
        public int TurnLength { get; set; }
        public int PostLength { get; set; }
        public int SourcesRequired { get; set; }
        public List<RoundState> Round { get; set; }
        public int NumberOfRounds { get; set; }
        public int NumberOfPlayersPerTeam { get; set; }
        public int Pot { get; set; }
        public bool SetupStage
        {
            get
            {
                if (Players.ReadyToStart)
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
