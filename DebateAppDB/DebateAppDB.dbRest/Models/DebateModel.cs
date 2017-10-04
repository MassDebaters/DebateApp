using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DebateAppDB.dbRest.Models
{
    public class DebateModel
    {
        /*public int Debate_id { get; set; }
        public string DebateString { get; set; }*/
        public object D { get; set; }

        private string path = @"~App_Data\DebateStrings.txt";

        

        public void AddDebate(DebateModel debate)//object debate)
        {
            //var definition = new { Name = "" };
            //add and return the max id
            string debates = File.ReadAllText(path);
            //var max = debates.Max(x => x.Key);

            var DebateList = JsonConvert.DeserializeObject<List<DebateModel>>(debates);
            
            //var DebateList = JsonConvert.DeserializeAnonymousType(s, definition);

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
            
            /*var max = DebateList.Max(x => x.Debate_id);
            debate.Debate_id = max + 1;*/

            var NewList = JsonConvert.SerializeObject(DebateList);
            File.WriteAllText(path, NewList);
        }


        ///-------------------------------------------

       /* public void AddDebate(string debate)//object debate)
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
        }*/

        public List<DebateModel> GetAllDebates()
        {
            var debates = File.ReadAllText(path);
            var DebateList = JsonConvert.DeserializeObject<List<DebateModel>>(debates);

            return DebateList;
        }

        public DebateModel GetDebate(int id)
        {
            string debates = File.ReadAllText(path);
            var DebateList = JsonConvert.DeserializeObject<List<DebateModel>>(debates);
            var debate = DebateList.ElementAt(id);//DebateList.FindAll(x => x.Debate_id == id).SingleOrDefault();
            //var debateString = JsonConvert.SerializeObject(debate);

            return debate;
        }

        public void UpdateDebate(int id, object newInfo)
        {
            string debates = File.ReadAllText(path);
            var DebateList = JsonConvert.DeserializeObject<List<DebateModel>>(debates);

            var debate = DebateList.ElementAt(id);//.FindAll(x => x.Debate_id == id).SingleOrDefault();
                                                  // debate.DebateString = newInfo;
            debate.D = newInfo;

            var NewList = JsonConvert.SerializeObject(DebateList);
            File.WriteAllText(path, NewList);
        }

        public int GetMaxIndex()
        {
            string s = File.ReadAllText(path);
            var DebateList = JsonConvert.DeserializeObject<List<DebateModel>>(s);
            var index = DebateList.Count - 1;

            return index;
        }
        public void DeleteDebate(int id)
        {
            string debates = File.ReadAllText(path);
            var DebateList = JsonConvert.DeserializeObject<List<DebateModel>>(debates);

            DebateList.RemoveAt(id);
        }
    }  
}
