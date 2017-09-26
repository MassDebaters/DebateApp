using DebateApp.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DebateApp.db
{
    class DBHelper
    {
        private DebateAppDBContext dbHelper;
        private List<JObject> jsonObjects;
        private List<string> DebateStrings;
        private StreamWriter FileOut;
        private StreamReader FileIn;
        private List<Debate> dList;

        public DBHelper()
        {
            dbHelper = new DebateAppDBContext();
            jsonObjects = new List<JObject>();
            DebateStrings = new List<string>();
            FileOut = new StreamWriter(@"C:\Revature\DebateApp\DebateApp\DebateApp.db\DebateStrings.txt");
            FileIn = new StreamReader(@"C:\Revature\DebateApp\DebateApp\DebateApp.db\DebateStrings.txt");
            dList = new List<Debate>();
        }

        public void AddAccount(string username, string password)
        {
            dbHelper.Accounts.Add(new Accounts() { Username = username, Password = password });
        }

        public void AddPost(int accId, int time)
        {
            dbHelper.Posts.Add(new Posts() { AccountId = accId, TimeStamp = time });
        }

        public void DeleteAccount(int id)
        {
            var account = dbHelper.Accounts.Find(id);

            if(account != null)
            {
                dbHelper.Accounts.Remove(account);
            }
        }

        public void DeletePost(int id)
        {
            var post = dbHelper.Posts.Find(id);

            if (post != null)
            {
                dbHelper.Posts.Remove(post);
            }
        }

        public bool UniqueUsername(string username)
        {
            var userName = dbHelper.Accounts.Where(un => un.Username == username);

            if(userName.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddDebate(object obj)
        {
            var result = JsonConvert.SerializeObject(obj);

            FileOut.WriteLine(result);//writing to text file
            FileOut.Close();//idk about this
        }


        public Casual GetDebate(int id)
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
        }

        public void ConvertDebatesToJsonObj()
        {
            string line;

            while ((line = FileIn.ReadLine()) != null)
            {
                JObject jo = JObject.Parse(line);
                jsonObjects.Add(jo);
            }
             
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

            System.IO.WriteAllText();


        }
    }
}
