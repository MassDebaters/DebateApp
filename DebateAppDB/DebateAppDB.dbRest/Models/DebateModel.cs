using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public object d { get; set; }

        private string path = @".\App_Data\DebateStrings.txt";

        public void Init()
        {
            var emptyLod = JsonConvert.SerializeObject(new List<DebateModel>());
            if (!File.Exists(path))
            {
                File.WriteAllText(path, emptyLod);
            }
        }

        public void AddDebate(DebateModel debate)
        {
            Init();
           
            var debates = File.ReadAllText(path);
            var DebateList = JsonConvert.DeserializeObject<List<DebateModel>>(debates);           
    
            var ModelToJson = JsonConvert.SerializeObject(debate);
            var JsonObject = JObject.Parse(ModelToJson);
            var property = JsonObject["d"];

            try
            {
                var lastDebate = DebateList.Last();
                var ModelToJsonLast = JsonConvert.SerializeObject(lastDebate);
                var JsonObjectLast = JObject.Parse(ModelToJsonLast);
             
                var id = JsonObjectLast.SelectToken(@"d.Debate_ID").Value<int>();

                property["Debate_ID"] = id + 1;
            }
            catch (Exception)
            {
                DebateList = new List<DebateModel>();
            
                property["Debate_ID"] = 1;
            }

            var updatedDebate = JsonConvert.DeserializeObject<DebateModel>(JsonObject.ToString());
            DebateList.Add(updatedDebate);

            var NewList = JsonConvert.SerializeObject(DebateList);
            File.WriteAllText(path, NewList);
        }

        public List<DebateModel> GetAllDebates()
        {
            Init();

            var debates = File.ReadAllText(path);
            
            var DebateList = JsonConvert.DeserializeObject<List<DebateModel>>(debates);

            return DebateList;
        }

        public DebateModel GetDebate(int id)
        {
            Init();
            string debates = File.ReadAllText(path);
            var DebateList = JsonConvert.DeserializeObject<List<DebateModel>>(debates);

            try
            {
                return DebateList.ElementAt(id);
            }
            catch(ArgumentOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException("id parameter is out of range.", e);
            }
        }

        public void UpdateDebate(int id, object newInfo)
        {
            Init();
            string debates = File.ReadAllText(path);
            var DebateList = JsonConvert.DeserializeObject<List<DebateModel>>(debates);

            var debate = DebateList.ElementAt(id);
                                              
            debate.d = newInfo;

            var NewList = JsonConvert.SerializeObject(DebateList);
            File.WriteAllText(path, NewList);
        }

        public int GetMaxIndex()
        {
            Init();
            string s = File.ReadAllText(path);
            var DebateList = JsonConvert.DeserializeObject<List<DebateModel>>(s);
            var index = DebateList.Count - 1;

            return index;
        }
        public void DeleteDebate(int id)
        {
            Init();
            string debates = File.ReadAllText(path);
            var DebateList = JsonConvert.DeserializeObject<List<DebateModel>>(debates);

            DebateList.RemoveAt(id);
        }

        public void OutOfRange(int id, int count)
        {
            if (id < 0 || id >= count)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }  

}
