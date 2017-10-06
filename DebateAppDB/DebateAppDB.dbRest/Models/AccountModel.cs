using DebateApp.db;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebateAppDB.dbRest.Models
{
    public class AccountModel
    {
        private readonly IConfiguration _Configuration;

        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public int Astros { get; set; }

        private DebateAppDBContext context;

        public AccountModel(IConfiguration configuration)
        {
            _Configuration = configuration;
            context = new DebateAppDBContext(_Configuration);
        }

        public List<AccountModel> GetAllAccounts()
        {
            List<AccountModel> accounts = new List<AccountModel>();

            foreach(var item in context.Accounts)
            {
                var account = new AccountModel(_Configuration) {AccountId = item.AccountId, Username = item.Username, Astros = item.Astros, Role = item.Role };

                accounts.Add(account);
            }
            return accounts;
        }

        public AccountModel GetAccount(int id)
        {
            var account = context.Accounts.Find(id);

            AccountId = account.AccountId;
            Username = account.Username;
            Astros = account.Astros;
            Role = account.Role;

            return this;
        }

        public AccountModel GetAccount(string un)
        {
            var account = context.Accounts.Where(u => u.Username == un).SingleOrDefault();

            AccountId = account.AccountId;
            Username = account.Username;
            Astros = account.Astros;
            Role = account.Role;

            return this;
        }

        public void AddAccount(Accounts account)
        {
            context.Accounts.Add(account);
            context.SaveChanges();
        }

        public void DeleteAccount(int id)
        {
            var account = context.Accounts.Find(id);

            if (account != null)
            {
                context.Accounts.Remove(account);
                context.SaveChanges();
            }
        }

        public bool UniqueUsername(string uName)
        {
            var userName = context.Accounts.Where(un => un.Username == uName);

            if (userName.Count() == 0 && uName.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetAstros(int id)
        {
            var account = context.Accounts.Find(id);

            return account.Astros;
        }

        public void AddAstros(int id, int astros)
        {
            var account = context.Accounts.Find(id);

            account.Astros = account.Astros + astros;

            context.SaveChanges();
        }

        public bool CheckLogin(string username, string password)
        {
            var account = context.Accounts.Where(a => a.Username == username && a.Password == password);

            if(account.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
