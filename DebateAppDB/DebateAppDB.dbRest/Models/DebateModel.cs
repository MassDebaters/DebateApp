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
        //add properties
        private string path = Directory.GetCurrentDirectory() + @"\DebateStrings.txt";
        //add function to write into file
        public void AddDebate(object debate)
        {
            string s = File.ReadAllText(path);

            var DebateList = JsonConvert.DeserializeObject<List<object>>(s);

            try
            {
                DebateList.Add(debate);
            }
            catch (Exception e)
            {
                DebateList = new List<object>
                {
                    debate
                };
            }

            var NewList = JsonConvert.SerializeObject(DebateList);
            File.WriteAllText(path, NewList);
        }

        public string GetAllDebates()
        { 
            return File.ReadAllText(path);
        }

    }  
}
