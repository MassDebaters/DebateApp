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
        private List<JObject> jsonObjects = new List<JObject>();
        private List<string> DebateStrings = new List<string>();
        //private StreamWriter FileOut = new StreamWriter("DebateStrings.txt");
        private StreamReader FileIn;
        private List<Debate> dList = new List<Debate>();

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

        public void AddDebate(object obj)
        {
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

            //FileOut.WriteLine(result);//writing to text file
            //FileOut.Close();//idk about this
        }


        /*public Casual GetDebate(int id)
        {
            var stringId = id.ToString();

            ConvertDebatesToJsonObj();

            JObject debate = jsonObjects.Values<JObject>()
                .Where(m => m["DebateId"].Value<string>() == stringId)
                .FirstOrDefault();

            var debateString = debate.ToString();

            Casual debateObject = JsonConvert.DeserializeObject<Casual>(debateString);

            jsonObjects.Clear();

            return debateObject;
        }*/

        public void ConvertDebatesToJsonObj()
        {
            string line;

            while ((line = FileIn.ReadLine()) != null)
            {
                JObject jo = JObject.Parse(line);
                jsonObjects.Add(jo);
            }
            FileIn.Close();
        }

        public void DeleteDebate(int id)
        {
            //read file and store to string list
            //look through string list and delete the one with id
            //
        }

        public void UpdateDebate(int id, List<Post> p)
        {

            dList = JsonConvert.DeserializeObject<List<Debate>>(FileIn.ReadToEnd());

            Debate d2 = dList.Find(d => d.DebateID == id);

            d2.Posts = p;

            var newInfo = JsonConvert.SerializeObject(dList);

            File.WriteAllText("DebateStrings.txt", newInfo);
        }
        public void AddDebate2(Debate d)
        {
            using (var stream = File.Open("DebateString.txt", FileMode.Open))
            {
                // Use stream
                FileIn = new StreamReader(stream);
                dList = JsonConvert.DeserializeObject<List<Debate>>(FileIn.ReadToEnd());
                dList.Add(d);
                var NewList = JsonConvert.SerializeObject(dList);
                File.WriteAllText("DebateStrings.txt", NewList);
            }
            
            //FileIn.Close();
            
        }
    }
}
