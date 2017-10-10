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
             
                var id = JsonObjectLast.SelectToken(@"d.debate_ID").Value<int>();

                property["debate_ID"] = id + 1;
            }
            catch (Exception)
            {
                DebateList = new List<DebateModel>();
            
                property["debate_ID"] = 1;
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
            var debate = new DebateModel();
            
            foreach(var item in DebateList)
            {

                var ModelToJson = JsonConvert.SerializeObject(item);
                var JsonObject = JObject.Parse(ModelToJson);
                var itemId = JsonObject.SelectToken(@"d.debate_ID").Value<int>();

                if(itemId == id)
                {
                    debate = JsonConvert.DeserializeObject<DebateModel>(JsonObject.ToString());
                    return debate;
                }

            }
            return debate;
        }

        public void UpdateDebate(int id, DebateModel newInfo)
        {
            Init();
            string debates = File.ReadAllText(path);
            var DebateList = JsonConvert.DeserializeObject<List<DebateModel>>(debates);

            foreach (var item in DebateList)
            {
             
                var ModelToJson = JsonConvert.SerializeObject(item);
                var JsonObject = JObject.Parse(ModelToJson);
                var itemId = JsonObject.SelectToken(@"d.debate_ID").Value<int>();

                if (itemId == id)
                {
                    item.d = newInfo.d;
                    break;
                }

            }

            var NewList = JsonConvert.SerializeObject(DebateList);
            File.WriteAllText(path, NewList);
        }

        public int GetLastId()
        {
            Init();
            string debates = File.ReadAllText(path);
            var DebateList = JsonConvert.DeserializeObject<List<DebateModel>>(debates);
            var lastDebate = DebateList.Last();
            var ModelToJsonLast = JsonConvert.SerializeObject(lastDebate);
            var JsonObjectLast = JObject.Parse(ModelToJsonLast);

            var id = JsonObjectLast.SelectToken(@"d.debate_ID").Value<int>();

            return id;
        }

        public void DeleteDebate(int id)
        {
            Init();
            string debates = File.ReadAllText(path);
            var DebateList = JsonConvert.DeserializeObject<List<DebateModel>>(debates);

            foreach (var item in DebateList)
            {

                var ModelToJson = JsonConvert.SerializeObject(item);
                var JsonObject = JObject.Parse(ModelToJson);
                var itemId = JsonObject.SelectToken(@"d.debate_ID").Value<int>();

                if (itemId == id)
                {
                    DebateList.Remove(item);
                    break;
                }
            }

            var NewList = JsonConvert.SerializeObject(DebateList);
            File.WriteAllText(path, NewList);
        }

        public void DeleteAllDebates()
        {
            Init();
           
            File.WriteAllText(path, string.Empty);
        }

    }  

}
