﻿using DebateAppDB.dbRest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DebateAppDB.test
{

    public class DBHelper
    {
        private HttpClient _client = new HttpClient();
        private string _api = "http://ec2-18-221-110-13.us-east-2.compute.amazonaws.com/DBapi/api/";
        private string GetDebate = "Debates/";
        private string GetUserById = "Accounts/";
        private string GetUserByUsername = "Accounts/getUser/";
        private string DeleteUser = "Accounts/";
        private string PostUser = "Accounts/";
        private string PostDebate = "Debates/";
        private string PutDebate = "Debates/";
        private string PutUser = "Accounts/";
        private string DeleteAllDebates = "Debates/";
        private string DeleteDebate = "Debates/";


        public DebateModel DBGetDebate(int id)
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

        public AccountModel DBGetUser(int id)
        {
            var res = _client.GetAsync(_api + GetUserById + id).GetAwaiter().GetResult();
            var ResObject = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<AccountModel>(ResObject);
            //result.Transfer();
            return result;
        }

        public IEnumerable<AccountModel> DBGetAllUser()
        {
            var res = _client.GetAsync(_api + GetUserById).GetAwaiter().GetResult();
            var ResObject = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<IEnumerable<AccountModel>>(ResObject);
            /*foreach (AccountModel u in result)
            {
                u.Transfer();
            }*/
            return result;
        }

        public AccountModel DBCreateUser(AccountModel u)
        {
            var body = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");
            var cd = _client.PostAsync(_api + PostUser, body);
            string cds = cd.GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<AccountModel>(cds);
            return result;
        }

        public void DBSaveUserChanges(AccountModel u)
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
