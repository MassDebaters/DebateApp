using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DebateAppDB.dbRest.Models
{
    public class DebateModel
    {
        public int Debate_id { get; set; }
        public string DebateString { get; set; }
        //add properties
        //private Dictionary<int, object> debates = new Dictionary<int, object>();
        private string path = Directory.GetCurrentDirectory() + @"\DebateStrings.txt";
        //add function to write into file
        public void AddDebate(DebateModel debate)//object debate)
        {
            //add and return the max id
            string s = File.ReadAllText(path);
            //var max = debates.Max(x => x.Key);

            var DebateList = JsonConvert.DeserializeObject<List<DebateModel>>(s);
            
            try
            {
                DebateList.Add(debate);
                //debates.Add(max + 1, debate);

            }
            catch (Exception e)
            {
                DebateList = new List<DebateModel>//<object>
                {
                    debate
                };

                //debates.Add(max + 1, debate);
            }

            var max = DebateList.Max(x => x.Debate_id);
            debate.Debate_id = max + 1;

            var NewList = JsonConvert.SerializeObject(DebateList);
            File.WriteAllText(path, NewList);
        }


        ///-------------------------------------------

        public void AddDebate(string debate)//object debate)
        {
            //add and return the max id
            string s = File.ReadAllText(path);
            //var max = debates.Max(x => x.Key);

            var DebateList = JsonConvert.DeserializeObject<List<DebateModel>>(s);
            var debateObject = JsonConvert.DeserializeObject<DebateModel>(debate);

            try
            {
                DebateList.Add(debateObject);
                //debates.Add(max + 1, debate);

            }
            catch (Exception e)
            {
                DebateList = new List<DebateModel>//<object>
                {
                    debateObject
                };

                //debates.Add(max + 1, debate);
            }

            var max = DebateList.Max(x => x.Debate_id);
            debateObject.Debate_id = max + 1;

            var NewList = JsonConvert.SerializeObject(DebateList);
            File.WriteAllText(path, NewList);
        }

        public List<DebateModel> GetAllDebates()
        {
            var debates = File.ReadAllText(path);
            var DebateList = JsonConvert.DeserializeObject<List<DebateModel>>(debates);

            return DebateList;
        }

        public DebateModel GetDebate(int id)
        {
            string s = File.ReadAllText(path);
            var DebateList = JsonConvert.DeserializeObject<List<DebateModel>>(s);

            var debate = DebateList.FindAll(x => x.Debate_id == id).SingleOrDefault();
            //var debateString = JsonConvert.SerializeObject(debate);

            return debate;
        }

        public void UpdateDebate(int id, object newInfo)
        {
            string s = File.ReadAllText(path);
            var DebateList = JsonConvert.DeserializeObject<List<DebateModel>>(s);

            var debate = DebateList.FindAll(x => x.Debate_id == id).SingleOrDefault();
           // debate.DebateString = newInfo;

            var NewList = JsonConvert.SerializeObject(DebateList);
            File.WriteAllText(path, NewList);
        }

        public int GetMaxIndex()
        {
            string s = File.ReadAllText(path);
            var DebateList = JsonConvert.DeserializeObject<List<DebateModel>>(s);
            var max = DebateList.Max(x => x.Debate_id);

            return max;
        }
    }  
}
