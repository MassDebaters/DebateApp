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
        private string _api = "http://ec2-18-221-110-13.us-east-2.compute.amazonaws.com/DBApi/api/";
        private string GetDebate = "Debates/Get";
        private string GetUser = "Accounts/";
        private string PostUser = "Accounts/Post/";
        private string PostDebate = "Debates/";
        private string PutDebate = "Debates/Put/";
        private string PutUser = "Accounts/Put/";


        public DebateModel DBGetDebate(int? id)
        {
            var res = _client.GetAsync(_api + GetDebate + id).GetAwaiter().GetResult();
            var ResObject = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<DebateModel>(ResObject);
            return result;
        }

        public IEnumerable<DebateModel> DBGetAllDebate()
        {
            var res = _client.GetAsync(_api + GetDebate).GetAwaiter().GetResult();
            var ResObject = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<IEnumerable<DebateModel>>(ResObject);
            return result;
        }

        public UserModel DBGetUser(int? id)
        {
            var res = _client.GetAsync(_api + GetUser + id).GetAwaiter().GetResult();
            var ResObject = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<UserModel>(ResObject);
            return result;
        }

        public IEnumerable<UserModel> DBGetAllUser()
        {
            var res = _client.GetAsync(_api + GetUser).GetAwaiter().GetResult();
            var ResObject = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<IEnumerable<UserModel>>(ResObject);
            return result;
        }

        public UserModel DBCreateUser(UserModel u)
        {
            var body = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");
            var cd = _client.PostAsync(_api + PostUser, body);
            string cds = cd.GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<UserModel>(cds);
            return result;
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
            var body = new StringContent(JsonConvert.SerializeObject(d), Encoding.UTF8, "application/json");
            var cd = _client.PutAsync(_api + PutDebate, body);
        }




    }
}
