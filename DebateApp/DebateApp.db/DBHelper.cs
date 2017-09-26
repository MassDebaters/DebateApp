using DebateApp.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DebateApp.db
{
    class DBHelper
    {
        private DebateAppDBContext dbHelper;
        private List<JObject> jsonObjects;

        public DBHelper()
        {
            dbHelper = new DebateAppDBContext();
            jsonObjects = new List<JObject>();
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

        public void ConvertToJson(object obj)
        {
            var result = JsonConvert.SerializeObject(obj);
            JObject jo = JObject.Parse(result);
            jsonObjects.Add(jo);
        }

        public string FindDebateFromJson(int id)
        {
            var stringId = id.ToString();
            
            JObject debate = jsonObjects.Values<JObject>()
                .Where(m => m["DebateId"].Value<string>() == stringId)
                .FirstOrDefault();

            var debateString = debate.ToString();

            return debateString;
        }
    }
}
