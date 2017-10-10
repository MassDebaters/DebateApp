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
        public double CurrentPotShareL { get; set; }
        public double CurrentPotShareR { get; set; }
        public string Status { get; set; }

        public void GetStage()
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
            else
            {
                Status = "Debate is still in Setup Stage!";
            }
        }

        public bool HaveAllVoted()
        {
            return Audience.TrueForAll(u => u.HasVoted);
        }

        public bool HaveAllResponded()
        {
            var ans = Teams.TrueForAll(t =>
            t.Members.TrueForAll(u =>
            u.HasResponded));
            return ans;
        }

        public void NextRound(bool timer)
        {
            var RoundCanEnd = (!timer && HaveAllResponded() && HaveAllVoted());
            if (timer || RoundCanEnd)
            {
                //set all previous rounds to active = false
                foreach (RoundState r in Round)
                {
                    r.Active = false;
                }

                //Calculate the Swings and apply to pot
                var previous = ActiveRound();
                previous.CalculateSwings();
                
                

                //create the new round
                Round.Add(new RoundState(previous));
                
                //reset responded & voted statuses
                foreach(Team t in Teams)
                {
                   foreach(User u in t.Members)
                    {
                        u.HasResponded = false;
                    }
                }
                foreach(User u in Audience)
                {
                    Pot += 4;
                    u.HasVoted = false;
                }
                CurrentPotShareL = previous.ShareL * Pot;
                CurrentPotShareR = previous.ShareR * Pot;

                var ar = ActiveRound();
                Status = "Round " + ar.CurrentTurn;
            }
            else
            {
                Status = "Waiting for Votes and Responses...";
            }
        }
    }
}
