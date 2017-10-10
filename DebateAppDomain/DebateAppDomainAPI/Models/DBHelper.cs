using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DebateAppDomainAPI.Models
{

    public class DBHelper
    {
        private HttpClient _client = new HttpClient();
        private string _api = "http://ec2-18-221-110-13.us-east-2.compute.amazonaws.com/DBapi/api/";
        private string GetDebate = "Debates/";
        private string GetUser = "Accounts/";
        private string PostUser = "Accounts/";
        private string PostDebate = "Debates/";
        private string PutDebate = "Debates/";
        private string PutUser = "Accounts/";


        public DebateModel DBGetDebate(int id)
        {
            var res = _client.GetAsync(_api + GetDebate + id).GetAwaiter().GetResult();
            var ResObject = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<DebateModel>(ResObject);
            return result;
        }

        public List<DebateModel> DBGetAllDebate()
        {
            var res = _client.GetAsync(_api + GetDebate).GetAwaiter().GetResult();
            var ResObject = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<List<DebateModel>>(ResObject);
            return result;
        }

        public UserModel DBGetUser(int id)
        {
            var res = _client.GetAsync(_api + GetUser + id).GetAwaiter().GetResult();
            var ResObject = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<UserModel>(ResObject);
            result.Transfer();
            return result;
        }

        public UserModel DBGetUser(string username)
        {
            var res = _client.GetAsync(_api + GetUser + "getUser/" + username).GetAwaiter().GetResult();
            var ResObject = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<UserModel>(ResObject);
            result.Transfer();
            return result;
        }

        public List<UserModel> DBGetAllUser()
        {
            var res = _client.GetAsync(_api + GetUser).GetAwaiter().GetResult();
            var ResObject = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<List<UserModel>>(ResObject);
            foreach(UserModel u in result)
            {
                u.Transfer();
            }
            return result;
        }
        public bool CheckUsername(string username)
        {
            var cd = _client.GetAsync(_api + "Accounts/username/" + username).GetAwaiter().GetResult();
            var cds = cd.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<bool>(cds);
            return result;
        }

        public UserModel DBCreateUser(UserModel u)
        {
            u.Astros = 100;
            u.Role = "User";
            if (CheckUsername(u.Username))
            {
                var body = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");
                var cd = _client.PostAsync(_api + PostUser, body).GetAwaiter().GetResult();
                var result = DBGetUser(u.Username);
                return result;
            }
            else
            {
                throw new Exception("Username is taken.");
            }
        }

        public void DBSaveUserChanges(UserModel u)
        {
            var body = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");
            var cd = _client.PutAsync(_api + PutUser, body);

        }

        public DebateModel DBCreateDebate(DebateModel d)
        {
            var text = JsonConvert.SerializeObject(d);
            var body = new StringContent(text, Encoding.UTF8, "application/json");
            var cd = _client.PostAsync(_api + PostDebate, body);
            string cds = cd.GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<DebateModel>(cds);
            return result;
        }

        public void DBSaveDebateChanges(DebateModel d)
        {
            d.d.UpdateLastGet();
            var body = new StringContent(JsonConvert.SerializeObject(d), Encoding.UTF8, "application/json");
            var cd = _client.PutAsync(_api + PutDebate + d.d.Debate_ID, body).GetAwaiter().GetResult();
        }

        public void DBDeleteDebate(int id)
        {
            _client.DeleteAsync(_api + "Debates/" + id).GetAwaiter().GetResult();
        }

        public void DBDeleteUser(int id)
        {
            _client.DeleteAsync(_api + "Accounts/" + id).GetAwaiter().GetResult();
        }

        //public DebateModel NextRound(int id, bool value)
        //{
        //    var debate = DBGetDebate(id);

        //    debate.d.NextRound(value);

        //    return debate;
        //}

        public DebateModel StartDebate(int id)
        {
            var debate = DBGetDebate(id);

            debate.d.StartDebate();

            return debate;
        }

        public DebateModel Vote(int id, DebateModel debate, bool value)
        {
            var user = DBGetUser(id);
            var updatedDebate = user.UserLogic.Vote(debate.d, value);
            debate.d = updatedDebate;

            return debate;
        }

        public DebateModel Post(int id, string comment, DebateModel debate)
        {
            var user = DBGetUser(id);
            var updatedDebate = user.UserLogic.Post(comment, debate.d);
            debate.d = updatedDebate;

            return debate;
        }

    }
}
