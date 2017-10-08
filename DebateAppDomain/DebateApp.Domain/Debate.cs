using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DebateApp.Domain
{
    public class Debate
    {
        public int Debate_ID {get; set;}
        
        public bool _gamestage { get; set; }

        public bool SetupStage { get;  set; }

        public string DebateTopic { get; set; }
        public string DebateCategory { get; set; }
        public static int NumberOfPlayersPerTeam { get; set; }
        public List<Team> Teams = new List<Team>();
        public List<User> Audience { get; set; }
        public int TurnLength { get; set; }
        public int PostLength { get; set; }
        public int SourcesRequired { get; set; }
        public List<RoundState> Round = new List<RoundState>();
        public RoundState ActiveRound() { return Round[Round.Count-1]; }
        public int NumberOfRounds { get; set; }
        public int Pot = 10;
        public string Status { get; set; }

        internal void GetStage()
        {
            if (Teams.TrueForAll(t => t.ReadyToStart))
            {
                _gamestage = true;
                Status = "Ready to Start!";
                SetupStage = false;
            }
            else
            {
                Status = "Setup Stage.";
                SetupStage = true;
                _gamestage = false;
            }

        }

        public void StartDebate()
        {
            var StartingRound = new RoundState()
            {
                Active = true
            };
            GetStage();
  
            if(_gamestage)
            {
                Round.Add(new RoundState(StartingRound));
                foreach(User u in Audience)
                {
                    Pot += 4;
                }
                var ar = this.ActiveRound();
                Status = "Round " + ar.CurrentTurn;
            }
            //else 
            //{
            //    Status = "Debate is still in Setup Stage!";
            //}
        }

        public void StartRound()
        {

        }
    }
}
