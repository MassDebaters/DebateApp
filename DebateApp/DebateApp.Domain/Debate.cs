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


        public int DebateID { get; set; }
        public List<Post> Posts { get; set; }
        public string DebateTopic { get; set; }
        public string DebateCategory { get; set; }
        public Dictionary<string,List<User>> Teams { get; set; }
        public List<User> Audience { get; set; }
        public int CurrentTurn { get; set; }
        public int TurnLength { get; set; }
        public int PostLength { get; set; }
        public int SourcesRequired { get; set; }
        public List<RoundState> Round { get; set; }
        public int NumberOfRounds { get; set; }
        public int Pot { get; set; }

     
        
        public string SaveDebate(Casual d)
        {
            var path = "C:\\Revature\\DebateApp\\DebateApp\\DebateApp.Domain\\DebateStrings.txt";
            string s = File.ReadAllText(path);
            
            var DebateList = JsonConvert.DeserializeObject<List<Casual>>(s);

            try
            {
                DebateList.Add(d);
            }
            catch(Exception e)
            {
                DebateList = new List<Casual>();
                DebateList.Add(d);
            }
            
            var NewList = JsonConvert.SerializeObject(DebateList);
            File.WriteAllText(path, NewList);
            return s;
            
        }
    }
}
